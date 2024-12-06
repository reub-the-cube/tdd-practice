namespace AoC._2024.day05.v1
{
    public class OrderingRule(int x, int y)
    {
        public bool AppliesTo(int value)
        {
            if (value == x || value == y)
            {
                return true;
            }
            return false;
        }

        public bool AppliesTo(IEnumerable<int> pagesToProduce)
        {
            return pagesToProduce.Contains(x) && pagesToProduce.Contains(y);
        }

        public bool IsMet(List<int> update)
        {
            return update.IndexOf(x) < update.IndexOf(y);
        }

        public List<int> MakePass(List<int> update)
        {
            if (!IsMet(update))
            {
                update[update.IndexOf(x)] = y;
                update[update.IndexOf(y)] = x;
                if (!IsMet(update)) throw new Exception("Could not make the rule pass.");
            }

            return update;
        }
    }
}
