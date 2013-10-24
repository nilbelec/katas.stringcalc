using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorKata
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _calc = new StringCalculator();

        [Test]
        public void EmptyStringShouldReturnZero()
        {
            _calc.Add(string.Empty).Should().Be(0);
        }

        [Test]
        public void NumbersShouldReturnTheSum()
        {
            _calc.Add("1").Should().Be(1);
            _calc.Add("3").Should().Be(3);
            _calc.Add("9").Should().Be(9);
            _calc.Add("1,2").Should().Be(3);
            _calc.Add("6,2").Should().Be(8);
            _calc.Add("2,2").Should().Be(4);
            _calc.Add("1,2,3").Should().Be(6);
            _calc.Add("6,2,0").Should().Be(8);
            _calc.Add("6,2,8").Should().Be(16);
        }

        [Test]
        public void CanUseNewLinesAsDelimiter()
        {
            _calc.Add("1\n2,3").Should().Be(6);
            _calc.Add("1\n2,3\n7").Should().Be(13);
            _calc.Add("1\n2,3\n2\n3\n4").Should().Be(15);
            _calc.Add("1\n2").Should().Be(3);
        }

        [Test]
        public void CAnUseCustomDelimiter()
        {
            _calc.Add("//;\n1\n2;3").Should().Be(6);
            _calc.Add("//&\n1\n2&3").Should().Be(6);
            _calc.Add("//;\n1;2;3").Should().Be(6);
        }

        [Test]
        public void NegativeNumbersThrowException()
        {
            Action action = () => _calc.Add("-1");
            action.ShouldThrow<InvalidOperationException>()
                .WithMessage("*negatives not allowed*-1*",ComparisonMode.Wildcard);
        }
    }
}
