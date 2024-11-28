using FluentAssertions;

namespace AoC._2015.day06.v1.Tests;

public class LightTests
{
    public class Constructor
    {
        [Fact]
        public void HasInitialStateOn()
        {
            var initialState = true;
            var position = new Position(0, 0);
            var light = new Light(initialState, position);

            light.IsOn().Should().Be(true);
        }

        [Fact]
        public void HasInitialStateOff()
        {
            var initialState = false;
            var position = new Position(0, 0);
            var light = new Light(initialState, position);

            light.IsOn().Should().Be(false);
        }
    }

    public class TurnOn
    {
        [Fact]
        public void ReturnsTrueForIsOn()
        {
            var initialState = false;
            var position = new Position(0, 0);
            var light = new Light(initialState, position);

            light.TurnOn();

            light.IsOn().Should().Be(true);
        }
    }

    public class TurnOff
    {
        [Fact]
        public void ReturnsFalseForIsOn()
        {
            var initialState = true;
            var position = new Position(0, 0);
            var light = new Light(initialState, position);

            light.TurnOff();

            light.IsOn().Should().Be(false);
        }

        // No tests for returns false if already off or true if already on
        // Does TDD demand it? Would be covered by outer loop tests?
    }

    public class Toggle
    {
        [Fact]
        public void ReturnsTrueForIsOnWhenLightIsOff()
        {
            var initialState = false;
            var position = new Position(0, 0);
            var light = new Light(initialState, position);

            light.Toggle();

            light.IsOn().Should().Be(true);
        }

        [Fact]
        public void ReturnsFalseForIsOnWhenLightIsOn()
        {
            var initialState = true;
            var position = new Position(0, 0);
            var light = new Light(initialState, position);

            light.Toggle();

            light.IsOn().Should().Be(false);
        }
    }
}