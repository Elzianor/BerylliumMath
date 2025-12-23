namespace Beryllium.Mathematics;

public static class Mathematics
{
    private const float ZeroTolerance = 1e-6f;

    public static bool IsZero(float a)
    {
        return Math.Abs(a) < ZeroTolerance;
    }

    public static bool IsOne(float a)
    {
        return IsZero(a - 1.0f);
    }

    public static bool IsMinusOne(float a)
    {
        return IsZero(a + 1.0f);
    }

    public static bool IsEqual(float a, float b)
    {
        return IsZero(a - b);
    }

    public static bool IsNotEqual(float a, float b)
    {
        return !IsEqual(a, b);
    }

    public static bool IsLessOrEqual(float a, float b)
    {
        return IsEqual(a, b) || a < b;
    }

    public static bool IsGreaterOrEqual(float a, float b)
    {
        return IsEqual(a, b) || a > b;
    }

    // How far between 'min' and 'max' is 'current'
    public static float InverseLerp(float current, float min, float max)
    {
        return (current - min) / (max - min);
    }

    // Remaps 'current' from [oldMin, oldMax] to [newMin, newMax]
    public static float Remap(float current, float oldMin, float oldMax, float newMin, float newMax)
    {
        return float.Lerp(newMin, newMax, InverseLerp(current, oldMin, oldMax));
    }
}
