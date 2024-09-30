using System.Drawing;

public class RgbColor
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public RgbColor(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static RgbColor operator +(RgbColor color, int value)
    {
        return new RgbColor(
            Math.Min(255, Math.Max(0, color.R + value)),
            Math.Min(255, Math.Max(0, color.G + value)),
            Math.Min(255, Math.Max(0, color.B + value))
        );
    }

    public static RgbColor operator -(RgbColor color, int value)
    {
        return new RgbColor(
            Math.Min(255, Math.Max(0, color.R - value)),
            Math.Min(255, Math.Max(0, color.G - value)),
            Math.Min(255, Math.Max(0, color.B - value))
        );
    }

    public int CompareTo(RgbColor other)
    {
        if (other == null) return 1;

        // Compare based on the sum of RGB values
        int thisSum = R + G + B;
        int otherSum = other.R + other.G + other.B;

        return thisSum.CompareTo(otherSum);
    }

    public static bool operator >(RgbColor left, RgbColor right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <(RgbColor left, RgbColor right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >=(RgbColor left, RgbColor right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator <=(RgbColor left, RgbColor right)
    {
        return left.CompareTo(right) <= 0;
    }

    public Color ToColor()
    {
        return Color.FromArgb(R, G, B);
    }
}