namespace AoC._2024.day05.v1
{
    public class OrderingRule(int x, int y)
    {
        public bool AppliesTo(int value)
        {
            return value == x || value == y;
        }

        public bool AppliesTo(IEnumerable<int> update)
        {
            return update.Contains(x) && update.Contains(y);
        }

        public bool IsMet(List<int> update)
        {
            return update.IndexOf(x) < update.IndexOf(y);
        }

        public void MakePass(List<int> update)
        {
            if (!IsMet(update))
            {
                update[update.IndexOf(x)] = y;
                update[update.IndexOf(y)] = x;
            }
        }
    }
}
