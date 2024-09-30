using Osussist.src.config;
using Osussist.src.osu;
using Osussist.src.osu.helpers;
using Osussist.src.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Osussist.src.cheat.aimbot
{
    public class Mouse
    {
        #region NativeImports
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        public const int MOUSEEVENTF_MOVE = 0x0001;
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        #endregion

        private static Logger logger = Logger.LoggingInstance;
        private static OsuSDK SDK { get; set; }

        public Mouse(OsuSDK givenSDK)
        {
            SDK = givenSDK;
        }

        public bool isGoodForMovement
        {
            get
            {
                if (Logic.isHoldingKeys)
                {
                    logger.Debug("Aimbot.Mouse", "Holding keys, stopping movement.");
                    return false;
                }
                else if (!Logic.isAimbotEnabled)
                {
                    logger.Debug("Aimbot.Mouse", "Aimbot disabled, stopping movement.");
                    return false;
                }
                else if (!SDK.isPlaying || SDK.isPaused || !SDK.isGameFocused)
                {
                    logger.Debug("Aimbot.Mouse", "Not playing, paused or game not in focus, stopping movement.");
                    return false;
                }
                return true;
            }
        }

        public void MoveAlgorithmSteps(Vector2 destinationCoords)
        {
            int steps = (int)System.Math.Round((double)Config.config.aimbotsettings.smoothing % SDK.GetRealMousePosition().LengthRelativeTo(destinationCoords));
            if (steps == 0)
            {
                logger.Debug("Aimbot.Mouse", "Destination is too close, skipping movement.");
                return;
            }
            int delay = new Random().Next(Config.config.aimbotsettings.movementdelay.from, Config.config.aimbotsettings.movementdelay.to) % steps;

            logger.Debug("Aimbot.Mouse", $"Moving mouse to {destinationCoords} in {steps} steps with a delay of {delay}ms.");

            Vector2 indexPosition = SDK.GetRealMousePosition();
            for (int i = 0; i < steps; i++)
            {
                if (!isGoodForMovement)
                    return;

                if (SDK.GetRealMousePosition().LengthRelativeTo(destinationCoords) < Config.config.aimbotsettings.hitobjectradius)
                {
                    logger.Debug("Aimbot.Mouse", "Mouse is close enough to destination, stopping movement.");
                    return;
                }
                else if (indexPosition.LengthRelativeTo(SDK.GetRealMousePosition()) > Config.config.aimbotsettings.pullawaydistance)
                {
                    logger.Debug("Aimbot.Mouse", "Mouse is too far away from index position, stopping movement.");
                    return;
                }

                Vector2 next = new Vector2(
                    (int)System.Math.Round((double)(destinationCoords.X - indexPosition.X) / (steps - i)) * Config.config.aimbotsettings.strength,
                    (int)System.Math.Round((double)(destinationCoords.Y - indexPosition.Y) / (steps - i)) * Config.config.aimbotsettings.strength
                );
                logger.Debug("Aimbot.Mouse", $"Moving mouse to {next.X}, {next.Y}.");
                mouse_event(MOUSEEVENTF_MOVE, (uint)next.X, (uint)next.Y, 0, 0);
                indexPosition = SDK.GetRealMousePosition();
                Thread.Sleep(delay);
            }
        }

        public void MoveAlgorithmBezier(Vector2 destinationCoords)
        {
            Vector2 currentPosition = SDK.GetRealMousePosition();

            if (!isGoodForMovement)
                return;

            if (SDK.GetRealMousePosition().LengthRelativeTo(destinationCoords) < Config.config.aimbotsettings.hitobjectradius)
            {
                logger.Debug("Aimbot.Mouse", "Mouse is close enough to destination, stopping movement.");
                return;
            }
            else if (currentPosition.LengthRelativeTo(SDK.GetRealMousePosition()) > Config.config.aimbotsettings.pullawaydistance)
            {
                logger.Debug("Aimbot.Mouse", "Mouse is too far away from index position, stopping movement.");
                return;
            }

            float movementDuration = 0.1f + (Config.config.aimbotsettings.smoothing / 100f) * 0.9f;
            int updateInterval = (int)(5 + (1 - Config.config.aimbotsettings.strength) * 15);

            Vector2 midPoint = Math.CalculateMidPoint(currentPosition, destinationCoords);
            float elapsedTime = 0f;
            Vector2 previousPosition = currentPosition;

            while (elapsedTime < movementDuration)
            {
                float t = elapsedTime / movementDuration;
                Vector2 newPosition = Math.CalculateBezierPoint(currentPosition, midPoint, destinationCoords, t);

                if (!isGoodForMovement)
                    return;

                if (SDK.GetRealMousePosition().LengthRelativeTo(destinationCoords) < Config.config.aimbotsettings.hitobjectradius)
                {
                    logger.Debug("Aimbot.Mouse", "Mouse is close enough to destination, stopping movement.");
                    return;
                }

                else if (newPosition.LengthRelativeTo(currentPosition) > Config.config.aimbotsettings.pullawaydistance)
                {
                    logger.Debug("Aimbot.Mouse", "Mouse is too far away from start position, stopping movement.");
                    return;
                }

                Vector2 delta = newPosition - previousPosition;
                logger.Debug("Aimbot.Mouse", $"Moving mouse by {delta.X}, {delta.Y}.");
                mouse_event(MOUSEEVENTF_MOVE, (uint)delta.X, (uint)delta.Y, 0, 0);

                previousPosition = newPosition;

                Thread.Sleep(updateInterval);
                elapsedTime += updateInterval / 1000f;
            }
            Vector2 finalDelta = destinationCoords - previousPosition;
            logger.Debug("Aimbot.Mouse", $"Final mouse move to {finalDelta.X}, {finalDelta.Y}.");
            mouse_event(MOUSEEVENTF_MOVE, (uint)finalDelta.X, (uint)finalDelta.Y, 0, 0);
            Thread.Sleep(new Random().Next(Config.config.aimbotsettings.movementdelay.from, Config.config.aimbotsettings.movementdelay.to));
        }

        public void MoveAlgorithmFlick(Vector2 destinationCoords)
        {
            Vector2 currentPosition = SDK.GetRealMousePosition();
            Thread.Sleep(new Random().Next(Config.config.aimbotsettings.movementdelay.from, Config.config.aimbotsettings.movementdelay.to));

            if (!isGoodForMovement)
                return;

            if (currentPosition.LengthRelativeTo(SDK.GetRealMousePosition()) > Config.config.aimbotsettings.pullawaydistance)
            {
                logger.Debug("Aimbot.Mouse", "Mouse moved, stopping movement.");
                return;
            }

            if (SDK.GetRealMousePosition().LengthRelativeTo(destinationCoords) < Config.config.aimbotsettings.hitobjectradius)
            {
                logger.Debug("Aimbot.Mouse", "Mouse is close enough to destination, stopping movement.");
                return;
            }
            else if (currentPosition.LengthRelativeTo(SDK.GetRealMousePosition()) > Config.config.aimbotsettings.pullawaydistance)
            {
                logger.Debug("Aimbot.Mouse", "Mouse is too far away from index position, stopping movement.");
                return;
            }

            Vector2 movementDiff = new Vector2(
                (destinationCoords.X - currentPosition.X) * Config.config.aimbotsettings.strength,
                (destinationCoords.Y - currentPosition.Y) * Config.config.aimbotsettings.strength
            );
            logger.Debug("Aimbot.Mouse", $"Moving mouse to {movementDiff.X}, {movementDiff.Y}.");
            mouse_event(MOUSEEVENTF_MOVE, (uint)movementDiff.X, (uint)movementDiff.Y, 0, 0);
            Thread.Sleep(new Random().Next(Config.config.aimbotsettings.movementdelay.from, Config.config.aimbotsettings.movementdelay.to));

            movementDiff = new Vector2(
                (currentPosition.X - destinationCoords.X) * Config.config.aimbotsettings.strength,
                (currentPosition.Y - destinationCoords.Y)* Config.config.aimbotsettings.strength
            );

            logger.Debug("Aimbot.Mouse", $"Moving mouse to {movementDiff.X}, {movementDiff.Y}.");
            mouse_event(MOUSEEVENTF_MOVE, (uint)movementDiff.X, (uint)movementDiff.Y, 0, 0);
            Thread.Sleep(new Random().Next(Config.config.aimbotsettings.movementdelay.from, Config.config.aimbotsettings.movementdelay.to));
        }

        public void MoveAlgorithmLinear(Vector2 destinationCoords)
        {
            Vector2 currentPosition = SDK.GetRealMousePosition();

            if (!isGoodForMovement)
                return;

            if (SDK.GetRealMousePosition().LengthRelativeTo(destinationCoords) < Config.config.aimbotsettings.hitobjectradius)
            {
                logger.Debug("Aimbot.Mouse", "Mouse is close enough to destination, stopping movement.");
                return;
            }
            else if (currentPosition.LengthRelativeTo(SDK.GetRealMousePosition()) > Config.config.aimbotsettings.pullawaydistance)
            {
                logger.Debug("Aimbot.Mouse", "Mouse is too far away from index position, stopping movement.");
                return;
            }

            if (SDK.GetRealMousePosition().LengthRelativeTo(destinationCoords) < Config.config.aimbotsettings.hitobjectradius)
            {
                logger.Debug("Aimbot.Mouse", "Mouse is close enough to destination, stopping movement.");
                return;
            }

            Vector2 movementDiff = new Vector2(
                (destinationCoords.X - currentPosition.X) * Config.config.aimbotsettings.strength, 
                (destinationCoords.Y - currentPosition.Y) * Config.config.aimbotsettings.strength
            );
            logger.Debug("Aimbot.Mouse", $"Moving mouse to {movementDiff.X}, {movementDiff.Y}.");
            mouse_event(MOUSEEVENTF_MOVE, (uint)movementDiff.X, (uint)movementDiff.Y, 0, 0);
            Thread.Sleep(new Random().Next(Config.config.aimbotsettings.movementdelay.from, Config.config.aimbotsettings.movementdelay.to));
        }
    }
}
