using System;

namespace Core;

public class Person
{
    private bool HasHireInProgress = false;
    private Scooter? HiredScooter;

    public bool StartHire(Scooter scooter)
    {
        if (ScooterHasBeenHired(scooter))
        {
            HasHireInProgress = true;
            HiredScooter = scooter;
            return true;
        }

        return false;
    }

    public void EndHire() {
        HasHireInProgress = false;
        HiredScooter?.Return();
    }

    private bool ScooterHasBeenHired(Scooter scooter)
    {
        if (!HasHireInProgress && scooter.Hire())
        {
            return true;
        }

        return false;
    }
}
