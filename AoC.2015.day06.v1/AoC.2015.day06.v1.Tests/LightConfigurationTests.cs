using FluentAssertions;

namespace AoC._2015.day06.v1.Tests;

public class LightConfigurationTests
{
    [Fact]
    public void TurnALightOn() 
    {
        var lightingConfiguration = new LightConfiguration();
        var instruction = new Instruction(LightAction.On, new Position(0,0), new Position(0,0));

        lightingConfiguration.Execute(instruction);

        lightingConfiguration.NumberOfLightsOn().Should().Be(1);
    }
}