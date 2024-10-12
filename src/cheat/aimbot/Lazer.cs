using OpenCvSharp;
using OpenCvSharp.Extensions;
using Osussist.src.config;
using Osussist.src.config.objects;
using Osussist.src.osu;
using Osussist.src.osu.helpers;
using Osussist.src.utils;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Windows.Forms;

namespace Osussist.src.cheat.aimbot
{
    public class Lazer
    {
        private Logger logger { get; set; }
        private OsuSDK SDK { get; set; }
        private Dictionary<string, Tuple<RgbColor, RgbColor>> ColorRanges { get; set; }
        private Mouse Mouse { get; set; }

        public Lazer(OsuSDK givenSDK)
        {
            SDK = givenSDK;
            logger = Logger.LoggingInstance;
            Mouse = new Mouse(SDK);
        }

        public void Loop()
        {
            try
            {
                RgbColor lastTargetColor = null;
                while (SDK.isGameFocused && !SDK.isPaused && Logic.isAimbotEnabled)
                {
                    Bitmap frame = CaptureScreen();
                    if (frame == null)
                    {
                        logger.Error("Aimbot.Lazer", "Failed to capture screen, retrying in 100ms.");
                        Thread.Sleep(100);
                        continue;
                    }
                    ColorRanges = new Dictionary<string, Tuple<RgbColor, RgbColor>>
                {
                    { "target", Tuple.Create(
                        Config.config.aimbotsettings.targetcolor - Config.config.aimbotsettings.similarity,
                        Config.config.aimbotsettings.targetcolor + Config.config.aimbotsettings.similarity)
                    },
                    { "cursor", Tuple.Create(
                        Config.config.aimbotsettings.cursorcolor - Config.config.aimbotsettings.similarity,
                        Config.config.aimbotsettings.cursorcolor + Config.config.aimbotsettings.similarity)
                    }
                };

                    List<Tuple<Vector2, RgbColor>> hitObjects = GetHitObjects(frame);
                    Tuple<Vector2, RgbColor> cursorObject = GetCursorPosition(frame);

                    if (hitObjects.Count() > 0)
                    {
                        hitObjects = hitObjects.OrderBy(h => h.Item1.LengthRelativeTo(cursorObject.Item1) <= Config.config.aimbotsettings.fovsize).ToList();

                        if (lastTargetColor != null && lastTargetColor != hitObjects.First().Item2)
                        {
                            if (!Logic.isHoldingKeys && hitObjects.First().Item1.LengthRelativeTo(cursorObject.Item1) <= Config.config.aimbotsettings.fovsize)
                            {
                                lastTargetColor = hitObjects.First().Item2;
                                PerformMove(hitObjects.First().Item1);
                            }
                        }
                        else
                        {
                            if (!Logic.isHoldingKeys && hitObjects.First().Item1.LengthRelativeTo(cursorObject.Item1) <= Config.config.aimbotsettings.fovsize)
                            {
                                lastTargetColor = hitObjects.First().Item2;
                                PerformMove(hitObjects.First().Item1);
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
            catch (Exception e)
            {
                logger.Error("Aimbot.Lazer", $"Unexpected error ocurred: {e.Message}");
            }
        }

        private void PerformMove(Vector2 hitObject)
        {
            if (Config.config.aimbotsettings.algorithm is MouseAlgorithms.Steps)
                Mouse.MoveAlgorithmSteps(hitObject);
            else if (Config.config.aimbotsettings.algorithm is MouseAlgorithms.Bezier)
                Mouse.MoveAlgorithmBezier(hitObject);
            else if (Config.config.aimbotsettings.algorithm is MouseAlgorithms.Linear)
                Mouse.MoveAlgorithmLinear(hitObject);
            else if (Config.config.aimbotsettings.algorithm is MouseAlgorithms.Flick)
                Mouse.MoveAlgorithmFlick(hitObject);
            else
            {
                logger.Warning("Aimbot.Lazer", "Invalid mouse algorithm, defaulting to steps.");
                Mouse.MoveAlgorithmSteps(hitObject);
            }
        }

        private static Bitmap CaptureScreen()
        {
            try
            {
                Rectangle bounds = Screen.PrimaryScreen.Bounds;

                if (bounds.Width <= 0 || bounds.Height <= 0)
                {
                    throw new ArgumentException($"Invalid screen dimensions: Width={bounds.Width}, Height={bounds.Height}");
                }

                Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
                }
                return bitmap;
            }
            catch (Exception ex)
            {
                Logger.LoggingInstance.Error("Aimbot.Lazer", $"Failed to capture screen: {ex.Message}");
                return null;
            }
        }

        private List<Tuple<Vector2, RgbColor>> GetHitObjects(Bitmap frame)
        {
            Tuple<RgbColor, RgbColor> hitObjectRange = ColorRanges["target"];
            List<Tuple<Vector2, RgbColor>> hitObjects = new List<Tuple<Vector2, RgbColor>>();

            Mat matFrame = BitmapConverter.ToMat(frame);
            Mat rgbFrame = new Mat();
            Cv2.CvtColor(matFrame, rgbFrame, ColorConversionCodes.BGR2RGB);

            Scalar lowerBound = new Scalar(hitObjectRange.Item1.R, hitObjectRange.Item1.G, hitObjectRange.Item1.B);
            Scalar upperBound = new Scalar(hitObjectRange.Item2.R, hitObjectRange.Item2.G, hitObjectRange.Item2.B);

            Mat mask = new Mat();
            Cv2.InRange(rgbFrame, lowerBound, upperBound, mask);

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(mask, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

            foreach (OpenCvSharp.Point[] contour in contours)
            {
                Vector2 hitObject = new Vector2();
                foreach (OpenCvSharp.Point point in contour)
                {
                    hitObject.X += point.X;
                    hitObject.Y += point.Y;
                }
                hitObject.X /= contour.Length;
                hitObject.Y /= contour.Length;

                int clampedX = System.Math.Min(System.Math.Max((int)hitObject.X + 20, 0), frame.Width - 1);
                int clampedY = System.Math.Min(System.Math.Max((int)hitObject.Y + 20, 0), frame.Height - 1);

                Color pixelColor = frame.GetPixel(clampedX, clampedY);

                RgbColor hitObjectBackground = new RgbColor(pixelColor.R, pixelColor.G, pixelColor.B);
                hitObjects.Add(new Tuple<Vector2, RgbColor>(hitObject, hitObjectBackground));
                logger.Debug("Aimbot.Lazer", $"Hit object found at {(int)hitObject.X}, {(int)hitObject.Y} with color ({hitObjectBackground.R},{hitObjectBackground.G},{hitObjectBackground.B})");
            }

            logger.Debug("Aimbot.Lazer", $"Found {hitObjects.Count} hit objects");
            return hitObjects;
        }

        private Tuple<Vector2, RgbColor> GetCursorPosition(Bitmap frame)
        {
            try
            {
                Tuple<RgbColor, RgbColor> cursorRange = ColorRanges["cursor"];

                Mat matFrame = BitmapConverter.ToMat(frame);
                Mat rgbFrame = new Mat();
                Cv2.CvtColor(matFrame, rgbFrame, ColorConversionCodes.BGR2RGB);

                Scalar lowerBound = new Scalar(cursorRange.Item1.R, cursorRange.Item1.G, cursorRange.Item1.B);
                Scalar upperBound = new Scalar(cursorRange.Item2.R, cursorRange.Item2.G, cursorRange.Item2.B);

                Mat mask = new Mat();
                Cv2.InRange(rgbFrame, lowerBound, upperBound, mask);

                OpenCvSharp.Point[][] contours;
                HierarchyIndex[] hierarchy;
                Cv2.FindContours(mask, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

                OpenCvSharp.Point[] largestContour = contours.OrderByDescending(c => Cv2.ContourArea(c)).First();

                Moments moments = Cv2.Moments(largestContour);
                double cx = System.Math.Round(moments.M10 / moments.M00);
                double cy = System.Math.Round(moments.M01 / moments.M00);

                int clampedX = System.Math.Min(System.Math.Max((int)cx + 20, 0), frame.Width - 1);
                int clampedY = System.Math.Min(System.Math.Max((int)cy + 20, 0), frame.Height - 1);
                Color pixelColor = frame.GetPixel(clampedX, clampedY);

                RgbColor rgbColor = new RgbColor(pixelColor.R, pixelColor.G, pixelColor.B);

                logger.Debug("Aimbot.Lazer" +
                    "", $"Cursor position: {cx}, {cy} and surround color is ({rgbColor.R},{rgbColor.G},{rgbColor.B})");
                return new Tuple<Vector2, RgbColor>(new Vector2((int)cx, (int)cy), rgbColor);
            }
            catch (Exception e)
            {
                logger.Error("Aimbot.Lazer" +
                    "", $"Failed to get cursor position: {e.Message}");
                return new Tuple<Vector2, RgbColor>(SDK.GetRealMousePosition(), new RgbColor(0, 0, 0));
            }
        }
    }
}
