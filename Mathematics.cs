namespace Beryllium.Mathematics;

public static class Mathematics
{
    private const float ZeroToleranceFloat = 1e-6f;
    private const double ZeroToleranceDouble = 1e-10;

    #region Comparison
    public static bool IsZero(float a)
    {
        return Math.Abs(a) < ZeroToleranceFloat;
    }

    public static bool IsZero(double a)
    {
        return Math.Abs(a) < ZeroToleranceDouble;
    }

    public static bool IsOne(float a)
    {
        return IsZero(a - 1.0f);
    }

    public static bool IsOne(double a)
    {
        return IsZero(a - 1.0f);
    }

    public static bool IsMinusOne(float a)
    {
        return IsZero(a + 1.0f);
    }

    public static bool IsMinusOne(double a)
    {
        return IsZero(a + 1.0f);
    }

    public static bool AreEqual(float a, float b)
    {
        return IsZero(a - b);
    }

    public static bool AreEqual(double a, double b)
    {
        return IsZero(a - b);
    }

    public static bool AreNotEqual(float a, float b)
    {
        return !AreEqual(a, b);
    }

    public static bool AreNotEqual(double a, double b)
    {
        return !AreEqual(a, b);
    }

    public static bool IsLessOrEqual(float a, float b)
    {
        return AreEqual(a, b) || a < b;
    }

    public static bool IsLessOrEqual(double a, double b)
    {
        return AreEqual(a, b) || a < b;
    }

    public static bool IsGreaterOrEqual(float a, float b)
    {
        return AreEqual(a, b) || a > b;
    }

    public static bool IsGreaterOrEqual(double a, double b)
    {
        return AreEqual(a, b) || a > b;
    }
    #endregion

    #region Clamping
    public static int ClampToPositive(int value)
    {
        return Math.Max(0, value);
    }

    public static float ClampToPositive(float value)
    {
        return Math.Max(0, value);
    }

    public static double ClampToPositive(double value)
    {
        return Math.Max(0, value);
    }
    #endregion

    #region Lerp / remapping
    public static float SecondsToDampingCoefficient(float convergenceFraction, float durationSec)
    {
        // Must be strictly in (0,1): 1.0 → log(0) = -Infinity, ≤0 → nonsense coefficient.
        convergenceFraction = Math.Clamp(convergenceFraction, 1e-4f, 1.0f - 1e-4f);

        var convergenceCoefficient = -MathF.Log(1.0f - convergenceFraction);

        return convergenceCoefficient / MathF.Max(durationSec, 1e-4f); // guard against div-by-zero
    }

    public static float InverseExpLerpAmount(float dampingCoefficient, float elapsedSeconds)
    {
        return 1.0f - MathF.Exp(-dampingCoefficient * elapsedSeconds);
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
    #endregion
}
