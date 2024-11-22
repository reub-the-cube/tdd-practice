namespace AoC._2015.day02.v1;

public class PresentList
{
    public static int RequiredWrappingPaperAmount(string presentDimensions)
    {
        var totalRequiredPaper = 0;
        var dimensions = presentDimensions.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).AsEnumerable();
        while (dimensions.Any())
        {
            var present = Present.FromDimension(dimensions.First());
            totalRequiredPaper += present.RequiredWrappingPaperSize();
            dimensions = dimensions.Skip(1);
        }

        return totalRequiredPaper;
    }

    public static int RequiredRibbonAmount(string presentDimensions)
    {
        var totalRequiredRibbon = 0;
        var dimensions = presentDimensions.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).AsEnumerable();
        while (dimensions.Any())
        {
            var present = Present.FromDimension(dimensions.First());
            totalRequiredRibbon += present.RequiredAmountOfRibbon();
            dimensions = dimensions.Skip(1);
        }

        return totalRequiredRibbon;
    }
}