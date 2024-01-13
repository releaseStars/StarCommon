using System;

public class ConversionHelper
{
    public static double ToDouble(string value) 
        => Convert.ToDouble(value);

    public static bool ToBool(string value)
        => Convert.ToBoolean(value);

    public static int ToInt(string value)
        => Convert.ToInt32(value);

    public static long ToLong(string value)
        => Convert.ToInt64(value);  

    public static float ToFloat(string value)
        => Convert.ToSingle(value);

    public static decimal ToDecimal(string value)
        => Convert.ToDecimal(value);

    public static DateTime ToDateTime(string value)
        => Convert.ToDateTime(value);
}
