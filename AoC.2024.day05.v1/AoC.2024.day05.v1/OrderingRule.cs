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

        public bool IsMet(List<int> update)
        {
            return update.IndexOf(x) < update.IndexOf(y);
        }
    }
}
