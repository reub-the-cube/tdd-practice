namespace AoC._2015.day06.v1;

public class Light
{
    private bool _isOn;
    public Light(bool initialState, object position)
    {
        _isOn = initialState;
    }

    public bool IsOn()
    {
        return _isOn;
    }

    public void TurnOn()
    {
        _isOn = true;
    }

    public void TurnOff()
    {
        _isOn = false;
    }

    public void Toggle()
    {
        _isOn = !_isOn;
    }
}