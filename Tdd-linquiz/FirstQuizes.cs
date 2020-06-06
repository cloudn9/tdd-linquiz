using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linquiz
{
    public partial class FirstQuizes
    {
        internal static int CountItems(List<string> list)
        {
            return list.Count;
        }

        internal static int CountWithAgg(List<string> list)
        {
            return list.Aggregate(0, (current, item) => current + 1);
        }

        internal static List<string> ConvertToLowercase(List<string> list)
        {
            return list.Select(l => l.ToLower()).ToList();
        }

        internal static List<string> StartingWith(List<string> list, string letter)
        {
            return list.Where(k => k.StartsWith(letter)).ToList();
        }

        internal static List<string> NotStartingWithLetters(List<string> list, string[] letters)
        {
            return list.Where(k => !letters.Contains(k.Substring(0, 1))).ToList();
        }

        internal static int CountItemsStartingWith(List<string> list, string v)
        {
            return list.Count(k => k.StartsWith(v));
        }

        internal static List<string> GetNames(List<Person> people)
        {
            return people.Select(k => k.Name).ToList();
        }

        internal static object CalculateLengthOfItem(List<string> list)
        {
            return list.Select(k => k.Length).ToList();
        }

        internal static object CalculateAllLetters(List<string> list)
        {
            return list.Aggregate(0, (current, item) => current + item.Length);
        }

        internal static object AddToNumbers(List<int> numbers)
        {
            return numbers.Select(k => k + 1).ToList();
        }

        internal static object FilterOddNumbers(List<int> numbers)
        {
            return numbers.Where(k => k % 2 == 0).ToList();
        }

        internal static object CountSmallerThen5(List<int> numbers)
        {
            return numbers.Count(k => k < 5);
        }

        internal static object PositionAsValue(List<int> numbers)
        {
            return numbers.Where(k => k == numbers.IndexOf(k)).ToList();
        }
    }
}
