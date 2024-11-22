using Aoc._2015.day04.v1;
using FluentAssertions;

namespace AoC._2015.day04.v1.Tests;

public class HasherTests
{
    public class LastHashedString
    {
        [Fact]
        public void ReturnsNothingBeforeAnyActions()
        {
            var hasher = new Hasher("secret");

            hasher.LastHashedString.Should().BeNull();
        }

        [Fact]
        public void ReturnsHashedValueAfterAHash()
        {
            var hasher = new Hasher("secret");

            hasher.MD5FromString("not_the_secret");

            hasher.LastHashedString.Should().Be("not_the_secret");
        }
    }

    public class IterateOnSecret
    {
        [Fact]
        public void ReturnsHashedValueForSecret()
        {
            var hasher = new Hasher("secret");
            var expectedHash = hasher.MD5FromString("secret1");

            var actualHash = hasher.IterateOnSecret();

            actualHash.Should().Be(expectedHash);
        }

        [Fact]
        public void LastHashedStringIncrementTheSecretAfterIterating()
        {
            var hasher = new Hasher("secret");

            hasher.IterateOnSecret();

            hasher.LastHashedString.Should().Be("secret1");
        }

        [Fact]
        public void LastHashedStringIncrementTheSecretAfterIteratingTwice()
        {
            var hasher = new Hasher("secret");

            hasher.IterateOnSecret();
            hasher.IterateOnSecret();

            hasher.LastHashedString.Should().Be("secret2");
        }
    }
}