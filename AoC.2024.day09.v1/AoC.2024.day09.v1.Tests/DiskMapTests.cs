using FluentAssertions;

namespace AoC._2024.day09.v1.Tests;

public class DiskMapTests
{
    public class ConstructorTests
    {
        [Fact]
        public void LeadsToCorrectRepresentationOfBlocksForAnEmptyString()
        {
            var diskMap = new DiskMap(string.Empty);

            string blocks = diskMap.AsBlocks();

            blocks.Should().Be(string.Empty);
        }

        [Fact]
        public void LeadsToCorrectRepresentationOfBlocksForASingeBlockFirstFile()
        {
            var diskMap = new DiskMap("1");

            string blocks = diskMap.AsBlocks();

            blocks.Should().Be("0");
        }

        [Fact]
        public void LeadsToCorrectRepresentationOfBlocksForADoubleBlockFirstFile()
        {
            var diskMap = new DiskMap("2");

            string blocks = diskMap.AsBlocks();

            blocks.Should().Be("00");
        }

        [Fact]
        public void LeadsToCorrectRepresentationOfBlocksForASingleBlockFirstFileAndSomeEmptySpace()
        {
            var diskMap = new DiskMap("23");

            string blocks = diskMap.AsBlocks();

            blocks.Should().Be("00...");
        }

        [Fact]
        public void LeadsToCorrectRepresentationOfBlocksForATwoFileBlocksAndSomeEmptySpace()
        {
            var diskMap = new DiskMap("233");

            string blocks = diskMap.AsBlocks();

            blocks.Should().Be("00...111");
        }
    }
}

// Length of file cannot be zero
// What about when file id is ten or more? 2 digits?