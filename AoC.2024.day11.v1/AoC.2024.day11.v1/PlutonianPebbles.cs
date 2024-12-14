namespace AoC._2024.day11.v1
{
    public class PlutonianPebbles
    {
        public PlutonianPebbles(string initialArrangement)
        {
            InitialArrangement = initialArrangement;
            currentArrangement = GetInitialArrangement();
        }

        private List<long> currentArrangement = [];

        public string InitialArrangement { get; }

        public long NumberOfStones { get; private set; }

        public override string ToString()
        {
            return string.Join(" ", currentArrangement);
        }

        public void Observe(int numberOfBlinks)
        {
            while (numberOfBlinks > 0)
            {
                var arrangement = currentArrangement.SelectMany(s => new Stone(s).OnBlink(1));
                currentArrangement = arrangement.Select(a => a.Value).ToList();
                numberOfBlinks--;
            }

            NumberOfStones = currentArrangement.Count;
        }

        private List<long> GetInitialArrangement()
        {
            return InitialArrangement.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        }
    }
}