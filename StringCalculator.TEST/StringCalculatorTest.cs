using System;
using Xunit;

namespace StringCalculator.TEST
{
    public class StringCalculatorTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1,\n", 1)]
        [InlineData("1,2", 3)]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[*][%]\n1*2%3", 6)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//[&&&&][&&&&]\n{10...}[&&&&]\n20[&&&&]\n1001...", 30)]
        public void ExtractNumbersFromStringAndAddThem(string numbers, int expected)
        {
            var result = Program.Add(numbers);

            Assert.Equal(expected, result);
        }
    }
}
