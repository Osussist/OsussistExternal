using System.Numerics;

namespace Osussist.src.osu.helpers
{
    public static class OsuExtensions
    {
        public static float NextFloat(this Random random, float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }

        public static bool AlmostEquals(this float f, float value, float allowance)
        {
            return Math.Abs(f - value) <= allowance;
        }

        public static int LengthRelativeTo(this Vector2 checkVec, Vector2 relVec)
        {
            return (int)Math.Sqrt(Math.Pow(checkVec.X - relVec.X, 2) + Math.Pow(checkVec.Y - relVec.Y, 2));
        }

        public static Vector2 Normalized(this Vector2 vector)
        {
            float length = vector.Length();
            if (length == 0)
            {
                return Vector2.Zero;
            }
            return vector / length;
        }
    }
}
