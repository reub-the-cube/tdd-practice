using FluentAssertions;

namespace RomanNumerals.Tests;

public class ConverterTests
{
    [InlineData(1000, "M")]
    [InlineData(1, "I")]
    [InlineData(1001, "MI")]
    [InlineData(2001, "MMI")]
    [InlineData(2000, "MM")]
    [InlineData(1002, "MII")]
    [InlineData(1005, "MV")]
    [InlineData(10, "X")]
    [InlineData(100, "C")]
    [InlineData(50, "L")]
    [InlineData(500, "D")]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    [InlineData(40, "XL")]
    [InlineData(90, "XC")]
    [InlineData(400, "CD")]
    [InlineData(900, "CM")]
    [InlineData(999, "CMXCIX")]
    [Theory]
    public void ConverterCanRepresentNumbersAsRomanNumerals(int arabic, string roman)
    {
        Converter.FromArabic(arabic).Should().Be(roman);
    }
}

/*
    ({} → nil) no code at all → code that employs nil
    (nil → constant)
    (constant → constant+) a simple constant to a more complex constant
    (constant → scalar) replacing a constant with a variable or an argument
    (statement → statements) adding more unconditional statements.
    (unconditional → if) splitting the execution path
    (scalar → array)
    (array → container)
    (statement → tail-recursion)
    (if → while)
    (statement → non-tail-recursion)
    (expression → function) replacing an expression with a function or algorithm
    (variable → assignment) replacing the value of a variable.
    (case) adding a case (or else) to an existing switch or if
*/