using System.Diagnostics;

namespace AoC._2024.day11.v1
{
    public class PlutonianPebbles(string InitialArrangement)
    {
        public long NumberOfStones { get; private set; }

        private readonly Dictionary<(long, int), long> _numberOfStonesAfterXBlinks = [];

        public void Observe(int numberOfBlinks)
        {
            NumberOfStones = GetInitialArrangement().Sum(s => Blink(numberOfBlinks, s));
        }

        private long Blink(int numberOfBlinks, long startingStoneValue)
        {
            if (numberOfBlinks == 0) return 1;

            if (!_numberOfStonesAfterXBlinks.ContainsKey((startingStoneValue, numberOfBlinks)))
            {
                var newStones = new Stone(startingStoneValue).OnBlink(1).Select(s => s.Value);
                _numberOfStonesAfterXBlinks.Add((startingStoneValue, numberOfBlinks), newStones.Sum(s => Blink(numberOfBlinks - 1, s)));
            }

            return _numberOfStonesAfterXBlinks[(startingStoneValue, numberOfBlinks)];
        }

        private List<long> GetInitialArrangement()
        {
            return InitialArrangement.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        }
    }
}