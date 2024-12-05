namespace AoC._2024.day05.v1
{
    public class PagesToProduce(List<OrderingRule> orderingRules, List<int> pages)
    {
        private List<List<OrderingRule>> RulesPerPage => pages.Select(p => orderingRules.Where(r => r.AppliesTo(pages)).Where(r => r.AppliesTo(p)).ToList()).ToList();

        public bool IsInOrder()
        {
            var allMet = NextPageRulesAreMet(RulesPerPage);
            return allMet;
        }

        public int MiddlePage()
        {
            return pages[(pages.Count - 1) / 2];
        }

        private bool NextPageRulesAreMet(List<List<OrderingRule>> pageRules)
        {
            if (pageRules.Count == 0)
            {
                return true;
            }

            var pageIsMet = NextRuleIsMet(pageRules.First());
            return pageIsMet && NextPageRulesAreMet(pageRules.Skip(1).ToList());
        }

        private bool NextRuleIsMet(List<OrderingRule> rules)
        {
            if (rules.Count == 0)
            {
                return true;
            }

            var nextRulesIsMet = rules.First().IsMet(pages);
            return nextRulesIsMet && NextRuleIsMet(rules.Skip(1).ToList());
        }
    }
}
