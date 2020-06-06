using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using static Linquiz.FirstQuizes;

namespace Linquiz
{
    public partial class FirstQuizesTest
    {
        [Fact]
        public void count_items()
        {
            var list = new List<string> { "foo", "bar", "baz", "qox" };

            var result = CountItems(list);

            result.Should().Be(4);
        }

        [Fact]
        public void count_items_using_aggregate()
        {
            var list = new List<string> { "foo", "bar", "baz", "qox" };

            var result = CountWithAgg(list);

            result.Should().Be(4);
        }

        [Fact]
        public void convert_strings_to_lowercase()
        {
            var list = new List<string> { "WhiteFox", "TADA", "HHkb" };

            var result = ConvertToLowercase(list);

            result.Should().BeEquivalentTo(new List<string> { "whitefox", "tada", "hhkb" });
        }

        [Fact]
        public void filter_strings_starting_with_the_letter_a()
        {
            var list = new List<string> { "amsterdam", "bar", "ametista", "rome", "antelope" };

            var result = StartingWith(list, "a");

            result.Should().BeEquivalentTo(new List<string> { "amsterdam", "ametista", "antelope" });
        }

        [Fact]
        public void filter_strings_not_starting_with_the_letter_a()
        {
            var list = new List<string> { "amsterdam", "bar", "ametista", "rome", "antelope" };

            var result = NotStartingWithLetters(list, new[] { "a" });

            result.Should().BeEquivalentTo(new List<string> { "bar", "rome" });
        }

        [Fact]
        public void filter_strings_not_starting_neither_with_the_letter_a_or_the_letter_r()
        {
            var list = new List<string> { "amsterdam", "bar", "ametista", "rome", "antelope" };

            var result = NotStartingWithLetters(list, new[] { "a", "r" }); ;

            result.Should().BeEquivalentTo(new List<string> { "bar" });
        }

        [Fact]
        public void count_strings_starting_with_the_letter_a()
        {
            var list = new List<string> { "amsterdam", "bar", "ametista", "rome", "antelope" };

            var result = CountItemsStartingWith(list, "a");

            result.Should().Be(3);
        }

        [Fact]
        public void extract_single_property_from_objects()
        {
            var people = new List<Person>
            {
                new Person{Name = "Stefano", Profession = "PM", Age = 45},
                new Person{Name = "Leo", Profession = "Developer", Age = 30},
                new Person{Name = "Ema", Profession = "Tester", Age = 18}
            };

            var result = GetNames(people);

            result.Should().BeEquivalentTo(new List<string> { "Stefano", "Leo", "Ema" });
        }

        [Fact]
        public void calculate_length_of_each_string()
        {
            var list = new List<string> { "one", "two", "three", "four" };

            var result = CalculateLengthOfItem(list);

            result.Should().BeEquivalentTo(new List<int> { 3, 3, 5, 4 });
        }

        [Fact]
        public void count_the_total_number_of_letters_in_all_the_strings()
        {
            var list = new List<string> { "one", "two", "three", "four" };

            var result = CalculateAllLetters(list);

            result.Should().Be(15);
        }

        [Fact]
        public void add_1_to_all_numbers()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = AddToNumbers(numbers);

            result.Should().BeEquivalentTo(new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
        }

        [Fact]
        public void filter_out_odd_numbers()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = FilterOddNumbers(numbers);

            result.Should().BeEquivalentTo(new List<int> { 2, 4, 6, 8, 10 });
        }

        [Fact]
        public void count_numbers_smaller_than_5()
        {
            var numbers = new List<int> { 10, 11, 2, 3, 100, 4, 1, 2 };

            var result = CountSmallerThen5(numbers);

            result.Should().Be(5);
        }

        [Fact]
        public void filter_numbers_whose_value_is_equal_than_its_position_in_the_list()
        {
            //                            0  1  2  3  4  5  6  7
            var numbers = new List<int> { 0, 1, 1, 3, 9, 9, 6, 6 };

            var result = PositionAsValue(numbers);

            result.Should().BeEquivalentTo(new List<int> { 0, 1, 3, 6 });
        }

        [Fact]
        public void associate_position_to_items_1_based()
        {
            var words = new List<string> { "one", "two", "three", "four", "five" };

            var result = new List<(string, int)>();

            result.Should().BeEquivalentTo(new List<(string, int)>
            {
                ("one", 1),
                ("two", 2),
                ("three", 3),
                ("four", 4),
                ("five", 5)
            });
        }

        [Fact]
        public void convert_numbers_to_words()
        {
            var words = new List<string> { "zero", "one", "two", "three", "four", "five" };
            var numbers = new List<int> { 1, 1, 2, 2, 1, 0, 3, 4, 1, 5 };

            var result = numbers;

            result.Should().BeEquivalentTo(new List<string>
            {
                "one", "one", "two", "two", "one", "zero", "three", "four", "one", "five"
            });
        }


        [Fact]
        public void reverse_items_in_tuples()
        {
            var numbers = new List<(string, int)>
            {
                ("one", 1),
                ("two", 2),
                ("three", 3),
                ("four", 4),
                ("five", 5)
            };

            var result = numbers;

            result.Should().BeEquivalentTo(new List<(int, string)>
            {
                (1, "one"),
                (2, "two"),
                (3, "three"),
                (4, "four"),
                (5, "five")
            });
        }

        [Fact]
        public void duplicate_list_items_as_pairs()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            var result = new List<(int, int)>();

            result.Should().BeEquivalentTo(new List<(int, int)> { (1, 1), (2, 2), (3, 3), (4, 4), (5, 5) });
        }

        [Fact]
        public void duplicate_list_items()
        {
            var numbers = new List<int> { 10, 2, 30, 4, 5 };

            var result = numbers;

            result.Should().BeEquivalentTo(new List<int> { 10, 10, 2, 2, 30, 30, 4, 4, 5, 5 });
        }

        [Fact]
        public void duplicate_a_list()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            var result = numbers;

            result.Should().BeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 });
        }

        [Fact]
        public void reverse_a_list()
        {
            var numbers = new List<string> { "foo", "bar", "baz" };

            var result = numbers;

            result.Should().ContainInOrder(new List<string> { "baz", "bar", "foo" });
        }

        [Fact]
        public void randomly_shuffle_a_list()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<int> Shuffle(IEnumerable<int> list)
            {
                // Implement here
                return list;
            }

            var results = Enumerable.Range(0, 100)
                .Select(i => Shuffle(numbers))
                .Distinct()
                .ToList();

            results.Count.Should().BeGreaterThan(1);

            results.ForEach(r => r.Should().BeEquivalentTo(numbers));
        }

        [Fact]
        public void sum_numbers_of_a_list()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            var result = 0;

            result.Should().Be(15);
        }

        [Fact]
        public void trim_strings()
        {
            var strings = new List<string>
            {
                " foo  ",
                "bar  ",
                "  baz"
            };

            var result = strings;

            result.Should().BeEquivalentTo(new List<string>
            {
                "foo",
                "bar",
                "baz"
            });
        }

        [Fact]
        public void take_the_first_element_of_a_list()
        {
            var numbers = new List<int> { 10, 20, 30, 40, 50 };

            var result = 0;

            result.Should().Be(10);
        }

        [Fact]
        public void take_the_second_element_of_a_list()
        {
            var numbers = new List<int> { 10, 20, 30, 40, 50 };

            var result = 0;

            result.Should().Be(20);
        }

        [Fact]
        public void take_the_second_element_of_a_list_without_using_Take()
        {
            var numbers = new List<int> { 10, 20, 30, 40, 50 };

            var result = 0;

            result.Should().Be(20);
        }

        [Fact]
        public void sum_numbers_of_a_list_using_Aggregate()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            var result = 0;

            result.Should().Be(15);
        }

        [Fact]
        public void remove_blacklisted_items()
        {
            var words = new List<string>
            {
                "foo",
                "bar",
                "forbidden",
                "baz",
                "skipme",
                "qux"
            };

            var forbiddenWords = new List<string>
                {"skipme", "forbidden"};

            var result = words;

            result.Should().BeEquivalentTo(new List<string>
            {
                "foo",
                "bar",
                "baz",
                "qux"
            });
        }

        [Fact]
        public void concatenate_strings_skipping_blacklisted_words()
        {
            var words = new List<string>
            {
                "foo",
                "bar",
                "forbidden",
                "baz",
                "skipme",
                "qux"
            };

            var forbiddenWords = new List<string>
                {"skipme", "forbidden"};

            var result = "";

            result.Should().Be("foobarbazqux");
        }

        [Fact]
        public void reverse_words_in_a_list()
        {
            var words = new List<string>
            {
                "foo",
                "bar",
                "baz",
                "qux"
            };

            var result = words;

            result.Should().BeEquivalentTo(new List<string>
            {
                "oof",
                "rab",
                "zab",
                "xuq"
            });
        }

        [Fact]
        public void count_word_occourrences()
        {
            var words = new List<string>
            {
                "baz",
                "foo",
                "bar",
                "baz",
                "foo",
                "foo",
                "qux"
            };

            var result = new Dictionary<string, int>();

            result.Should().BeEquivalentTo(new Dictionary<string, int>
            {
                {"foo", 3},
                {"bar", 1},
                {"baz", 2},
                {"qux", 1}
            });
        }

        [Fact]
        public void count_word_occourrences_removing_words_that_appears_only_once()
        {
            var words = new List<string>
            {
                "baz",
                "foo",
                "bar",
                "baz",
                "foo",
                "foo",
                "qux",
                "qux"
            };

            var result = new Dictionary<string, int>();

            result.Should().BeEquivalentTo(new Dictionary<string, int>
            {
                {"foo", 3},
                // {"bar", 1},  // removed, as it appears only once
                {"baz", 2},
                {"qux", 2}
            });
        }

        [Fact]
        public void only_keep_items_that_have_less_than_2_occourrences()
        {
            var words = new List<string>
            {
                "baz",
                "foo",
                "bar",
                "baz",
                "foo",
                "foo", // There are 3 occourrences of "foo". Remove all of them
                "qux"
            };

            var result = words;

            result.Should().BeEquivalentTo(new List<string>
            {
                "baz",
                "bar",
                "baz",
                "qux"
            });
        }

        [Fact]
        public void only_keep_up_to_2_occourrences_of_an_item()
        {
            var words = new List<string>
            {
                "baz",
                "foo",
                "bar",
                "baz",
                "foo",
                "foo", // This is the 3rd "foo" occourrences. Remove it
                "qux",
                "qux",
                "qux", // 3rd and
                "qux" // 4th occourrences of "qux" must be removed
            };

            var result = words;

            result.Should().BeEquivalentTo(new List<string>
            {
                "baz",
                "foo",
                "bar",
                "baz",
                "foo",
                // "foo",
                "qux",
                "qux",
                // "qux",
                // "qux"
            });
        }

        [Fact]
        public void zip_lists()
        {
            var people = new List<string>
            {
                "Stefano",
                "Leo",
                "Ale",
            };

            var drinks = new List<string>()
            {
                "water",
                "Martini dry",
                "vodka"
            };

            var result = people;

            result.Should().BeEquivalentTo(new List<string>
            {
                "Stefano drinks water",
                "Leo drinks Martini dry",
                "Ale drinks vodka"
            });
        }

        [Fact]
        public void multiply_numbers_from_2_lists()
        {
            var numbers1 = new List<int> { 2, 3, 4 };
            var numbers2 = new List<int> { 10, 100, 1000 };

            var result = numbers1;

            result.Should().BeEquivalentTo(new List<int> { 20, 300, 4000 });
        }

        [Fact]
        public void calculate_squares()
        {
            var numbers = new List<int> { 2, 3, 4 };

            var result = numbers;

            result.Should().BeEquivalentTo(new List<int> { 4, 9, 16 });
        }

        [Fact]
        public void find_all_possible_couples()
        {
            var words = new List<int>
            {
                1,
                2,
                3
            };

            var result = new List<(int, int)>();

            result.Should().BeEquivalentTo(new List<(int, int)>
            {
                (1, 1),
                (1, 2),
                (1, 3),

                (2, 1),
                (2, 2),
                (2, 3),

                (3, 1),
                (3, 2),
                (3, 3)
            });
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(7, true)]
        [InlineData(8, false)]
        [InlineData(9, false)]
        [InlineData(14, false)]
        [InlineData(17, true)]
        public void check_if_a_number_is_prime(int number, bool expected)
        {
            bool IsPrime(int n)
            {
                // implement here with LINQ
                throw new NotImplementedException();
            }

            IsPrime(number).Should().Be(expected);
        }

        [Fact]
        public void check_if_list_contains_at_least_one_item_satisfying_a_property()
        {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 1, 3, 5 };

            bool ContainsAtLeastAnEvenNumber(IEnumerable<int> list)
            {
                // implement here with LINQ
                throw new NotImplementedException();
            }

            ContainsAtLeastAnEvenNumber(a).Should().Be(true);
            ContainsAtLeastAnEvenNumber(b).Should().Be(false);
        }

        [Fact]
        public void check_if_list_contains_only_items_satisfying_a_property()
        {
            var a = new List<int> { 2, 4, 6 };
            var b = new List<int> { 1, 3, 5 };

            bool ContainsOnlyEvenNumbers(IEnumerable<int> list)
            {
                // implement here with LINQ
                throw new NotImplementedException();
            }

            ContainsOnlyEvenNumbers(a).Should().Be(true);
            ContainsOnlyEvenNumbers(b).Should().Be(false);
        }

        [Fact]
        public void check_if_all_the_items_satisfy_all_the_required_properties()
        {
            var a = new List<int> { 2, 4, 8 };
            var b = new List<int> { 1, 4, 8 };
            var c = new List<int> { 2, 4, 500 };
            var d = new List<int> { 2, 6, 8 };

            var rules = new Dictionary<string, Func<int, bool>>
            {
                {"is even", n => n % 2 == 0},
                {"is not 6", n => n != 6},
                {"is smaller than 100", n => n < 100}
            };

            bool SatisfiesAllTheRules(IEnumerable<int> list)
            {
                // implement here with LINQ
                throw new NotImplementedException();
            }

            SatisfiesAllTheRules(a).Should().Be(true);
            SatisfiesAllTheRules(b).Should().Be(false);
            SatisfiesAllTheRules(c).Should().Be(false);
            SatisfiesAllTheRules(d).Should().Be(false);
        }

        [Fact]
        public void concatenate_lists()
        {
            var list1 = new List<int> { 1, 2, 3, 4 };
            var list2 = new List<int> { 5, 6, 7 };

            var result = list1;

            result.Should().BeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
        }

        [Fact]
        public void interleave_2_lists_items()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };

            var result = list1;

            result.Should().BeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6 });
        }

        [Fact]
        public void keep_only_matching_part_of_two_list()
        {
            var list1 = new List<int> { 5, 2, 3, 17, 19, 100, 200 };
            var list2 = new List<int> { 5, 2, 3, 17, 19, 888, 300, 100 };

            var result = list1;

            result.Should().BeEquivalentTo(new List<int> { 5, 2, 3, 17, 19 });
        }

        [Fact]
        public void collect_the_non_matching_items_from_the_first_list()
        {
            var list1 = new List<int> { 5, 2, 3, 17, 19, 100, 200 };
            var list2 = new List<int> { 5, 2, 3, 17, 19, 888, 300, 100 };

            var result = list1;

            result.Should().BeEquivalentTo(new List<int> { 100, 200 });
        }

        [Fact]
        public void collect_the_non_matching_items_from_all_the_lists()
        {
            var list1 = new List<int> { 5, 2, 3, 17, 19, 100, 200 };
            var list2 = new List<int> { 5, 2, 3, 17, 19, 888, 300, 100 };

            var result = list1;

            result.Should().ContainInOrder(new List<int> { 100, 200, 888, 300, 100 });
        }

        [Fact]
        public void find_the_last_matching_item_in_2_lists()
        {
            var list1 = new List<int> { 5, 2, 3, 17, 19, 100, 200 };
            var list2 = new List<int> { 5, 2, 3, 17, 19, 888, 300, 100 };

            var result = 0;

            result.Should().Be(19);
        }

        [Fact]
        public void take_the_central_element_of_a_list_with_an_odd_number_of_items()
        {
            var list = new List<int> { 5, 2, 3, 17, 19, 100, 200 };

            var result = 0;

            result.Should().Be(17);
        }
    }
}