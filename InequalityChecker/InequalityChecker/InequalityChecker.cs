namespace InequalityChecker;

public class InequalityChecker
{
    public GuessOutcome SubmitGuess(int firstValue, int secondValue, char operand)
    {
        var correctOperand = CorrectOperand(firstValue, secondValue);
        
        return new() {
            IsCorrect = correctOperand == operand,
            ShouldHaveBeen = correctOperand
        };
    }

    private char CorrectOperand(int firstValue, int secondValue) 
    {
        if (firstValue < secondValue)
        {
            return '<';
        } else if (firstValue > secondValue)
        {
            return '>';
        }
        return '_';
    }
}

public class GuessOutcome
{
    public bool IsCorrect {get;set;}
    public char ShouldHaveBeen {get;set;}
}
