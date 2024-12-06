namespace AoC._2024.day05.v1
{
    public class SafetyManualUpdate(List<int> pagesToUpdate, List<OrderingRule> orderingRules)
    {
        private List<List<OrderingRule>> RulesPerPage => pagesToUpdate.Select(p => orderingRules.Where(r => r.AppliesTo(p)).ToList()).ToList();

        public bool AllPageRulesAreMet()
        {
            return NextPageRulesAreMet(RulesPerPage);
        }

        public bool NextPageRulesAreMet(List<List<OrderingRule>> pageRules)
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

            var nextRulesIsMet = rules.First().IsMet(pagesToUpdate);
            if (!nextRulesIsMet)
            {
                rules.First().MakePass(pagesToUpdate);
            }
            return nextRulesIsMet && NextRuleIsMet(rules.Skip(1).ToList());
        }
    }
}
