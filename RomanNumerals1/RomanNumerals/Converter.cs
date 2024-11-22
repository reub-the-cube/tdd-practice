using System.Net;

namespace RomanNumerals;
public class Converter
{
    private readonly static Dictionary<int, string> KnownConversionFactors = new()
    {
        { 1000, "M"},
        { 900, "CM"},
        { 500, "D"},
        { 400, "CD"},
        { 100, "C"},
        { 90, "XC"},
        { 50, "L"},
        { 40, "XL"},
        { 10, "X"},
        { 9, "IX"},
        { 5, "V"},
        { 4, "IV"},
        { 1, "I"}
    };

    private static int currentValue = 0;
    private static int nextKnownConversionFactor = 0;

    public static string FromArabic(int value)
    {
        if (value == 0) return "";
        if (KnownConversionFactors.ContainsKey(value))
        {
            return KnownConversionFactors[value];
        }

        return BreakdownNumeralsForCurrentValue(value);
    }

    private static string BreakdownNumeralsForCurrentValue(int value)
    {
        currentValue = value;
        nextKnownConversionFactor = KnownConversionFactors.First(x => currentValue > x.Key).Key;
        
        return GetNumeralForCurrentFactor() + GetNumeralForRemainder();
    }

    private static string GetNumeralForCurrentFactor()
    {
        int wholeQuotient = currentValue / nextKnownConversionFactor;
        string conversionNumeral = FromArabic(nextKnownConversionFactor);
        return string.Concat(Enumerable.Repeat(conversionNumeral, wholeQuotient));
    }

    private static string GetNumeralForRemainder()
    {
        int remainder = currentValue % nextKnownConversionFactor;
        return FromArabic(remainder);
    }

}