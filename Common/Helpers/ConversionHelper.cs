public static class ConversionHelper
{
    public static double? ToDouble(string value)
    {
        double result;
        if (double.TryParse(value, out result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public static bool ToBool(string value)
    {
        bool result;
        if (bool.TryParse(value, out result))
        {
            return result;
        }
        else
        {
            return false;
        }
    }
}
