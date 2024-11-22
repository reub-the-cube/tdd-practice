namespace AoC._2015.day02.v1;

public class Present
{
    public static Present FromDimension(string input)
    {
        var dimensions = input.Split("x");

        return new Present(int.Parse(dimensions[0]), int.Parse(dimensions[1]), int.Parse(dimensions[2]));
    }

    private readonly int _height = 0;
    private readonly int _length = 0;
    private readonly int _width = 0;
    private int _areaLengthAndWidth = 0;
    private int _areaLengthAndHeight = 0;
    private int _areaWidthAndHeight = 0;
    private int _perimeterLengthAndWidth = 0;
    private int _perimeterLengthAndHeight = 0;
    private int _perimeterWidthAndHeight = 0;

    private Present(int length, int width, int height)
    {
        _length = length;
        _width = width;
        _height = height;

        GenerateMetricsOfEachSide();
    }

    public int AreaOfSmallestSide()
    {
        return Enumerable.Min(new int[] { _areaLengthAndWidth, _areaLengthAndHeight, _areaWidthAndHeight });
    }

    private int PerimeterOfSmallestSide()
    {
        return Enumerable.Min(new int[] { _perimeterLengthAndWidth, _perimeterLengthAndHeight, _perimeterWidthAndHeight });
    }

    public int RequiredWrappingPaperSize()
    {
        var area = 2 * (_areaLengthAndWidth + _areaLengthAndHeight + _areaWidthAndHeight);

        return area + AreaOfSmallestSide();
    }

    public int RequiredAmountOfRibbon()
    {
        var volume = _length * _width * _height;

        return volume + PerimeterOfSmallestSide();
    }

    private void GenerateMetricsOfEachSide()
    {
        GenerateAreasOfEachSide();
        GeneratePerimetersOfEachSide();
    }

    private void GenerateAreasOfEachSide()
    {
        _areaLengthAndWidth = _length * _width;
        _areaLengthAndHeight = _length * _height;
        _areaWidthAndHeight = _width * _height;
    }

    private void GeneratePerimetersOfEachSide()
    {
        _perimeterLengthAndWidth = 2 * (_length + _width);
        _perimeterLengthAndHeight = 2 * (_length + _height);
        _perimeterWidthAndHeight = 2 * (_width + _height);
    }
}
