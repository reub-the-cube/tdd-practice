namespace AoC._2024.day05.v1
{
    public class SafetyManualProtocol
    {
        public readonly List<OrderingRule> Rules;
        public readonly List<List<int>> PagesToProduce;

        public SafetyManualProtocol(string[] input)
        {
            var rowBreak = input.ToList().IndexOf(string.Empty);
         
            Rules = CreateOrderingRules(input.Take(rowBreak));
            PagesToProduce = CreatePagesToProduce(input.Skip(rowBreak + 1));
        }

        public List<int> MiddleNumberOfEachCorrectUpdate()
        {
            var correctlyOrderedUpdates = CorrectlyOrderedUpdates();
            return correctlyOrderedUpdates.Select(p => p.MiddlePage()).ToList();
        }

        public int NumberOfCorrectUpdates()
        {
            var correctlyOrderedUpdates = CorrectlyOrderedUpdates();
            return correctlyOrderedUpdates.Count();
        }

        private IEnumerable<PagesToProduce> CorrectlyOrderedUpdates()
        {
            return PagesToProduce
                .Select(p => new PagesToProduce(Rules, p))
                .Where(p => p.IsInOrder());
        }

        private List<OrderingRule> CreateOrderingRules(IEnumerable<string> ruleRows)
        {
            return ruleRows.Select(CreateOrderingRule).ToList();
        }

        private OrderingRule CreateOrderingRule(string inputRow)
        {
            var xAndY = inputRow.Split('|');
            
            return new(int.Parse(xAndY[0]), int.Parse(xAndY[1]));
        }

        private List<List<int>> CreatePagesToProduce(IEnumerable<string> pagesToProduceRows)
        {
            return pagesToProduceRows.Select(p =>
            {
                return p.Split(',').Select(int.Parse).ToList();
            }).ToList();
        }
    }
}
