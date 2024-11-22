namespace Core;
public class Scooter
{
    private bool IsHired = false;

    public bool Hire()
    {
        if (IsHired)
        {
            return false;
        }

        IsHired = true;
        return true;
    }

    public void Return()
    {
        IsHired = false;
    }
}
