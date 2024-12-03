using FluentAssertions;

namespace AoC._2024.day03.v1.Tests;

public class MemoryInterpreterTests
{
    public class GetInstructionsFrom
    {
        [Theory]
        [InlineData("mul(2,1)")]
        [InlineData("mul(2,2)")]
        [InlineData("mul(200,199)")]
        public void CanFindMultiplicationInstructionsFromCorruptedMemoryIfPresent(string corruptedMemoryInput)
        {
            var corruptedMemory = new List<string> { corruptedMemoryInput };

            var instructions = MemoryInterpreter.GetInstructionsFrom(corruptedMemory);

            instructions.Should().HaveCount(1);
            instructions.First().Should().NotBe(null);
        }

        [Theory]
        [InlineData("")]
        [InlineData("mul(1,)")]
        public void CannotFindMultiplicationInstructionsFromCorruptedIfNotPresent(string corruptedMemoryInput)
        {
            var corruptedMemory = new List<string> { corruptedMemoryInput };

            var instructions = MemoryInterpreter.GetInstructionsFrom(corruptedMemory);

            instructions.Should().HaveCount(0);
        }

        [Fact]
        public void CanFindMultipleMultiplicationInstructionsFromCorruptedMemoryIfPresent()
        {
            var corruptedMemory = new List<string> { "mul(1,3)fnosnmul(3,mul(2,3)z* zsz\\" };

            var instructions = MemoryInterpreter.GetInstructionsFrom(corruptedMemory);

            instructions.Should().HaveCount(2);
        }

        [Fact]
        public void CanFindMultipleMultiplicationInstructionsFromMultipleLinesOfCorruptedMemory()
        {
            var corruptedMemory = new List<string> { "mul(1,3)fnosnmul(3,", "mul(2,3)z* zsz\\", "os -0 ?QW /pl@" };

            var instructions = MemoryInterpreter.GetInstructionsFrom(corruptedMemory);

            instructions.Should().HaveCount(2);
        }
    }

    public class MapToMultiplicationInstruction
    {
        [Fact]
        public void CreatesInstruction()
        {
            var fromString = "mul(2,5)";

            var actualInstruction = MemoryInterpreter.MapToMultiplicationInstruction(fromString);

            actualInstruction.Result.Should().Be(10);
        }

        [Fact]
        public void CreatesInstructionForAlternateInput()
        {
            var fromString = "mul(5,3)";

            var actualInstruction = MemoryInterpreter.MapToMultiplicationInstruction(fromString);

            actualInstruction.Result.Should().Be(15);
        }
    }
}