using FluentAssertions;

namespace AoC._2024.day05.v1.Tests
{
    public class OrderingRuleTests
    {
        private readonly OrderingRule _orderingRule;
        public OrderingRuleTests()
        {
            _orderingRule = new OrderingRule(3, 4);
        }

        public class IsMet : OrderingRuleTests
        {
            [Fact]
            public void ReturnsTrueWhenXIsBeforeY()
            {
                var isMet = _orderingRule.IsMet([3, 4]);

                isMet.Should().BeTrue();
            }

            [Fact]
            public void ReturnsFalseWhenXIsNotBeforeY()
            {
                var isMet = _orderingRule.IsMet([4, 3]);

                isMet.Should().BeFalse();
            }
        }

        public class AppliesTo : OrderingRuleTests
        {
            [Fact]
            public void ReturnsTrueWhenTheValueIsX()
            {
                var appliesTo = _orderingRule.AppliesTo(3);

                appliesTo.Should().BeTrue();
            }

            [Fact]
            public void ReturnsTrueWhenTheValueIsY()
            {
                var appliesTo = _orderingRule.AppliesTo(4);

                appliesTo.Should().BeTrue();
            }

            [Fact]
            public void ReturnsFalseWhenTheValueNotXOrY()
            {
                var appliesTo = _orderingRule.AppliesTo(5);

                appliesTo.Should().BeFalse();
            }

            [Fact]
            public void ReturnsTrueWhenXAndYAreInThePageList()
            {
                var appliesTo = _orderingRule.AppliesTo([2, 3, 4, 5]);

                appliesTo.Should().BeTrue();
            }

            [Fact]
            public void ReturnsFalseWhenYIsNotInThePageList()
            {
                var appliesTo = _orderingRule.AppliesTo([2, 3, 5]);

                appliesTo.Should().BeFalse();
            }

            [Fact]
            public void ReturnsFalseWhenXIsNotInThePageList()
            {
                var appliesTo = _orderingRule.AppliesTo([2, 4, 5]);

                appliesTo.Should().BeFalse();
            }
        }

    }
}

/*
 * In the string, <value_at_current_index>, needs to appear:
 *     after a value if it's Y in a rule, AND
 *     before a value if it's X in a rule
 *     */

// arg exception if value is not x or y
// arg exception if x is not in the list
// arg exception if y is not in the list