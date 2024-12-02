namespace AoC._2024.day02.v1
{
    public class ReactorReport(List<string> reportInput)
    {
        private const int safeGap = 3;
        private readonly List<int> _reportInput = reportInput.Select(int.Parse).ToList();
        private LevelDirection _levelDirection = LevelDirection.NotSet;

        public bool IsSafe()
        {
            SetInitialLevelDirection();
            return IsStillSafe();
        }

        private void SetInitialLevelDirection()
        {
            if (_reportInput.Count > 1)
            {
                if (_reportInput[0] > _reportInput[1])
                {
                    _levelDirection = LevelDirection.EverDecreasing;
                }
                else if (_reportInput[0] < _reportInput[1])
                {
                    _levelDirection = LevelDirection.EverIncreasing;
                }
            }
        }

        private bool IsStillSafe()
        {
            if (_reportInput.Count < 2)
            {
                return true;
            }

            if (!IsNextNumberSafe())
            {
                return false;
            }

            _reportInput.RemoveAt(0);
            return IsStillSafe();
        }

        private bool IsNextNumberSafe()
        {
            if (_reportInput[0] == _reportInput[1])
            {
                return false;
            }

            if (_reportInput[0] + safeGap < _reportInput[1])
            {
                return false;
            }

            if (_reportInput[0] - safeGap > _reportInput[1])
            {
                return false;
            }

            if (_reportInput[0] > _reportInput[1] && _levelDirection == LevelDirection.EverIncreasing)
            {
                return false;
            }

            if (_reportInput[0] < _reportInput[1] && _levelDirection == LevelDirection.EverDecreasing)
            {
                return false;
            }

            return true;
        }

        private enum LevelDirection
        {
            NotSet,
            EverIncreasing,
            EverDecreasing
        }
    }
}
