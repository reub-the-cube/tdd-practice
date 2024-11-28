namespace AoC._2015.day06.v1;

public record Instruction(LightAction action, object from, object to)
{

}

public enum LightAction
{
    On
}