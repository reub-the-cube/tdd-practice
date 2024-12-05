using FluentAssertions;
using System.Security;

namespace AoC._2024.day05.v1.Tests
{
    public class PagesToProduceTests
    {
        public class IsInOrder
        {
            [Fact]
            public void ReturnsTrueWhenAllRulesAreMet()
            {
                var ruleSet = new List<OrderingRule>() { new(3, 4) };
                var pages = new List<int>() { 3, 4 };

                var pagesToProduce = new PagesToProduce(ruleSet, pages);

                var isInOrder = pagesToProduce.IsInOrder();

                isInOrder.Should().BeTrue();
            }

            [Fact]
            public void ReturnsFalseWhenFirstRuleIsNotMet()
            {
                var ruleSet = new List<OrderingRule>() { new(3, 4) };
                var pages = new List<int>() { 4, 3 };

                var pagesToProduce = new PagesToProduce(ruleSet, pages);

                var isInOrder = pagesToProduce.IsInOrder();

                isInOrder.Should().BeFalse();
            }

            [Fact]
            public void ReturnsFalseWhenSecondRuleIsNotMet()
            {
                var ruleSet = new List<OrderingRule>() { new(3, 4), new(3, 5) };
                var pages = new List<int>() { 5, 3, 4 };

                var pagesToProduce = new PagesToProduce(ruleSet, pages);

                var isInOrder = pagesToProduce.IsInOrder();

                isInOrder.Should().BeFalse();
            }

            [Fact]
            public void ReturnsTrueWhenThereIsARuleThatDoesNotApply()
            {
                var ruleSet = new List<OrderingRule>() { new(3, 4), new(5, 6) };
                var pages = new List<int>() { 5, 6 };

                var pagesToProduce = new PagesToProduce(ruleSet, pages);

                var isInOrder = pagesToProduce.IsInOrder();

                isInOrder.Should().BeTrue();
            }
        }
    }
}
