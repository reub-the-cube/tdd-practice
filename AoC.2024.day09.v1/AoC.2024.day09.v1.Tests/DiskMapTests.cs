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

        [Fact]
        public void LeadsToCorrectRepresentationOfBlocksForFirstExampleProvided()
        {
            var diskMap = new DiskMap("12345");

            string blocks = diskMap.AsBlocks();

            blocks.Should().Be("0..111....22222");
        }

                [Fact]
        public void LeadsToCorrectRepresentationOfBlocksForSecondExampleProvided()
        {
            var diskMap = new DiskMap("2333133121414131402");

            string blocks = diskMap.AsBlocks();

            blocks.Should().Be("00...111...2...333.44.5555.6666.777.888899");
        }
    }
}

// Length of file cannot be zero
// What about when file id is ten or more? 2 digits?