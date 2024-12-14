namespace AoC._2024.day10.v1;

public class Map
{
    private readonly Position[,] _map;
    private readonly List<Position> _trailheads = [];
    private readonly Dictionary<Position, int> _finishingPositions = [];
    private readonly Dictionary<Position, Dictionary<Position, int>> _finishingPositionsByStartingPosition = [];

    public int Height { get; init; }
    public int Width { get; init; }

    private const int MaximumTopographicHeight = 9;

    public Map(string[] input)
    {
        input = input.Reverse().ToArray(); // Index 0 is actually row 0
        var rows = Enumerable.Range(0, input.Length).ToList();
        var columns = Enumerable.Range(0, input[0].Length).ToList();

        Height = rows.Count;
        Width = columns.Count;

        _map = new Position[Width, Height];
        rows.ForEach(r => columns.ForEach(c =>
        {
            var position = new Position(c, r, int.Parse(input[r][c].ToString()));
            _map[c, r] = position;
            if (_map[c, r].Height == 0)
            {
                _trailheads.Add(position);
            }
        }
        ));
    }

    public List<Position> FindTrailheads()
    {
        return _trailheads;
    }

    public Position PositionAt(int x, int y)
    {
        return _map[x, y];
    }

    public int RatingFromTrailheads()
    {
        return _trailheads.Sum(RatingFrom);
    }

    public int RatingFrom(Position position)
    {
        _ = ScoreFrom(position);
        return _finishingPositionsByStartingPosition[position].Sum(p => p.Value);
    }

    public int ScoreFrom(Position position)
    {
        _finishingPositions.Clear();

        IEnumerable<Position> positions = [position];
        while (positions.Any())
        {
            positions = positions.SelectMany(GetNextPositions);
        }

        _finishingPositionsByStartingPosition[position] = _finishingPositions;

        return _finishingPositions.Count();
    }

    public int ScoreFromTrailheads()
    {
        return _trailheads.Sum(ScoreFrom);
    }

    private IEnumerable<Position> GetNextPositions(Position position)
    {
        if (AddFinishingPosition(position))
        {
            return [];
        }

        return position.Next(this);
    }

    private bool AddFinishingPosition(Position position)
    {
        var atTopHeight = position.Height == MaximumTopographicHeight;
        if (atTopHeight)
        {
            if (!_finishingPositions.TryGetValue(position, out int value))
            {
                value = 0;
                _finishingPositions.Add(position, value);
            }
            _finishingPositions[position] = ++value;
        }

        return atTopHeight;
    }
}