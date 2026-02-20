namespace Beryllium.Mathematics;

public static class Mathematics
{
    private const float ZeroToleranceFloat = 1e-6f;
    private const double ZeroToleranceDouble = 1e-10;

    #region Comparison
    public static bool IsZero(float a) => Math.Abs(a) < ZeroToleranceFloat;
    public static bool IsZero(double a) => Math.Abs(a) < ZeroToleranceDouble;

    public static bool IsOne(float a) => IsZero(a - 1.0f);
    public static bool IsOne(double a) => IsZero(a - 1.0f);
    
    public static bool IsMinusOne(float a) => IsZero(a + 1.0f);
    public static bool IsMinusOne(double a) => IsZero(a + 1.0f);

    public static bool AreEqual(float a, float b) => IsZero(a - b);
    public static bool AreEqual(double a, double b) => IsZero(a - b);

    public static bool AreNotEqual(float a, float b) => !AreEqual(a, b);
    public static bool AreNotEqual(double a, double b) => !AreEqual(a, b);

    public static bool IsLessOrEqual(float a, float b) => AreEqual(a, b) || a < b;
    public static bool IsLessOrEqual(double a, double b) => AreEqual(a, b) || a < b;
    
    public static bool IsGreaterOrEqual(float a, float b) => AreEqual(a, b) || a > b;
    public static bool IsGreaterOrEqual(double a, double b) => AreEqual(a, b) || a > b;
    #endregion

    #region Clamping
    public static int ClampToPositive(int value) => Math.Max(0, value);
    public static float ClampToPositive(float value) => Math.Max(0, value);
    public static double ClampToPositive(double value) => Math.Max(0, value);
    #endregion

    #region Lerp / remapping
    // How far between 'min' and 'max' is 'current'
    public static float InverseLerp(float current, float min, float max) => (current - min) / (max - min);

    // Remaps 'current' from [oldMin, oldMax] to [newMin, newMax]
    public static float Remap(float current, float oldMin, float oldMax, float newMin, float newMax)
        => float.Lerp(newMin, newMax, InverseLerp(current, oldMin, oldMax));
    #endregion
}
