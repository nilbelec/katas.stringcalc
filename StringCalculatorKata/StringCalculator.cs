using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly IList<char> _delimiters = new List<char>{',','\n'};

        public int Add(string numbers)
        {
            if (numbers.StartsWith("//"))
                numbers = RemoveCustomDelimiter(numbers);
            var list = ParseToInts(numbers);
            return list.Sum();
        }

        private IEnumerable<int> ParseToInts(string numbers)
        {
            var numberList = numbers
                .Split(_delimiters.ToArray()
                       , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            if (numberList.Any(x => x < 0))
                throw new InvalidOperationException("negatives not allowed: " + showNegativeNumbers(numberList));
            return numberList;
        }

        private string showNegativeNumbers(IEnumerable<int> numberList)
        {
            var negatives = numberList.Where(x => x < 0).Distinct();
            return numberList.Aggregate(string.Empty, (current, number) => current + (" " + number));
        }

        private string RemoveCustomDelimiter(string numbers)
        {
            _delimiters.Add(numbers.Substring(2,1)[0]);
            return numbers.Substring(3);
        }
    }
}