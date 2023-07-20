using Katas;
using Xunit;

namespace KatasTests
{
    public class A_number_is_fizz
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void If_it_is_divisible_by_3(uint number)
        {
            Assert.Equal("fizz", FizzBuzz.ToFizzBuzz(number));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(13)]
        public void If_it_is_divisible_by_3_or_contains_3(uint number)
        {
            Assert.Equal("fizz", FizzBuzz.ToFizzBuzzExtended(number));
        }
    }

    public class A_number_is_buzz
    {
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void If_it_is_divisible_by_5(uint number)
        {
            Assert.Equal("buzz", FizzBuzz.ToFizzBuzz(number));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(52)]
        public void If_it_is_divisible_by_5_or_contains_5(uint number)
        {
            Assert.Equal("buzz", FizzBuzz.ToFizzBuzzExtended(number));
        }
    }

    public class A_number_is_fizzbuzz
    {
        [Theory]
        [InlineData(15)]
        public void If_it_is_divisible_by_3_and_5(uint number)
        {
            Assert.Equal("fizzbuzz", FizzBuzz.ToFizzBuzz(number));
        }

        [Theory]
        [InlineData(15)]
        [InlineData(35)]
        [InlineData(53)]
        public void If_it_is_divisible_by_3_and_5_or_contains_3_and_5(uint number)
        {
            Assert.Equal("fizzbuzz", FizzBuzz.ToFizzBuzzExtended(number));
        }
    }

    public class A_number_is_a_number
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(31)]
        [InlineData(52)]
        public void If_it_is_not_divisible_by_3_or_5(uint number)
        {
            Assert.Equal(number.ToString(), FizzBuzz.ToFizzBuzz(number));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(41)]
        [InlineData(79)]
        public void If_it_is_not_divisible_by_3_or_5_and_does_not_contains_3_or_5(uint number)
        {
            Assert.Equal(number.ToString(), FizzBuzz.ToFizzBuzzExtended(number));
        }
    }
}
