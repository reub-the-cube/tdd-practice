namespace AoC._2024.day05.v1
{
    public class PagesToProduce(List<OrderingRule> orderingRules, List<int> pages)
    {
        private List<OrderingRule> ApplicableRulesForPageSet => orderingRules.Where(r => r.AppliesTo(pages)).ToList();
        private SafetyManualUpdate SafetyManualUpdate => new(pages, ApplicableRulesForPageSet);

        public bool IsInOrder()
        {
            var allMet = SafetyManualUpdate.AllPageRulesAreMet();
            return allMet;
        }

        public int MiddlePage()
        {
            return pages[(pages.Count - 1) / 2];
        }

        public List<int> Reorder()
        {
            var isInOrder = false;
            while (!isInOrder)
            {
                isInOrder = SafetyManualUpdate.AllPageRulesAreMet();
            }

            return pages;
        }
    }
}
