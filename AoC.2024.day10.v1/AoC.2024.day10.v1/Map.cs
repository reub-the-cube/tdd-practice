using System.IO.IsolatedStorage;
using System.Security.Cryptography.X509Certificates;

namespace AoC._2024.day10.v1;

public class Map
{
    private readonly Position[,] _map;

    public int Height { get; init; }
    public int Width { get; init; }

    public Map(string[] input)
    { 
        input = input.Reverse().ToArray(); // Index 0 is actually row 0
        var rows = Enumerable.Range(0, input.Length).ToList();
        var columns = Enumerable.Range(0, input[0].Length).ToList();

        Height = rows.Count;
        Width = columns.Count;
        
        _map = new Position[Width, Height];
        rows.ForEach(r => columns.ForEach(c => _map[c, r] = new Position(c, r, int.Parse(input[r][c].ToString()))));
    }

    public Position PositionAt(int x, int y)
    {
        return _map[x, y];
    }

    public int ScoreFrom(Position position)
    {
        if (position.Height == 9)
        {
            return 1;
        }

        return 0;
    }
}