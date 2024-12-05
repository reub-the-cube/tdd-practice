using FluentAssertions;

namespace AoC._2024.day05.v1.Tests
{
    public class InputTests
    {
        private readonly string[] inputText = File.ReadAllLines("input.txt");

        [Fact]
        public void InputTextContains50Lines()
        {
            inputText.Should().HaveCount(1382);
        }
    }
}
