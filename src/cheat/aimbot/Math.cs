using Osussist.src.osu.helpers;
using System.Numerics;

namespace Osussist.src.cheat.aimbot
{
	public class Math
	{
		public static Vector2 CalculateMidPoint(Vector2 point1, Vector2 point2)
		{
			Vector2 direction = point2 - point1;
			Vector2 perpendicular = new Vector2(-direction.Y, direction.X);
			float randomOffset = (float)(new Random().NextDouble() - 0.5) * direction.Length() * 0.5f;
			return (point1 + point2) / 2 + perpendicular.Normalized() * randomOffset;
		}

		public static Vector2 CalculateBezierPoint(Vector2 start, Vector2 control, Vector2 end, float t)
		{
			float u = 1 - t;
			float tt = t * t;
			float uu = u * u;

			Vector2 point = uu * start;
			point += 2 * u * t * control;
			point += tt * end;

            return point;
        }

        public static int Clamp(int value, int min, int max)
        {
            return System.Math.Max(min, System.Math.Min(max, value));
        }
    }
}
