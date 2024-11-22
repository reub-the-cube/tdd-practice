using FluentAssertions;

namespace Wordle.Tests;

public class UnitTest1
{
    [Fact]
    public void WhenThereAreNoMatchingCharactersAllZerosAreReturns()
    {
        var target = "ropes";
        var guess = "child";

        var result = new Checker().HowCloseIsTheWord(target, guess);

        result.Should().Be("00000");
    }

    [Fact]
    public void WhenTheCharacterMatchesATwoIsReturned()
    {
        var target = "alert";
        var guess = "alarm";

        var result = new Checker().HowCloseIsTheWord(target, guess);

        result.Should().Be("22020");
    }

    [Fact]
    public void WhenTheCharacterIsInTheWrongPositionAOneIsReturned()
    {
        var target = "stair";
        var guess = "chore";

        var result = new Checker().HowCloseIsTheWord(target, guess);
        result.Should().Be("00010");

        target = "bleak";
        result = new Checker().HowCloseIsTheWord(target, guess);
        result.Should().Be("00001");
    }

    [Fact]
    public void WhenThereIsAMixtureOfMatchesTheyCanBeCombined()
    {
        var target = "hairy";
        var guess = "charm";

        var result = new Checker().HowCloseIsTheWord(target, guess);
        result.Should().Be("01120");

        target = "reads";
        guess = "elects";
        result = new Checker().HowCloseIsTheWord(target, guess);
        result.Should().Be("10000");
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

===========
Requirments
===========

Create a program, which, given a 5 character string as a target word, and a 5 character string as a guess, return a 5 character string where:

‘2’ = this letter is in this position
‘1’ = this letter is in the target word but not this position
‘0’ = this letter is either not in the target word, or is not in the target word as many times as it is in the guess
Examples
No matching characters
Target = “ropes”
Guess  = “child”
Result = “00000”
Characters match in correct positions
Target = “alert”
Guess  = “alarm”
Result = “22020”
Character in wrong position
Target = “stair”
Guess  = “chore”
Result = “00010”
Mix of match and wrong position
Target = “hairy”
Guess  = “charm”
Result = “01120”
Multiple characters in wrong positions
Target = “reads”
Guess  = “elect”
Result = “10000”
*/

