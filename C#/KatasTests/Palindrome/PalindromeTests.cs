using System;
using Katas.Palindrome;
using Xunit;

namespace KatasTests.Palindrome
{
    public class PalindromeTests
    {
        [Fact]
        public void Empty()
        {
            // act
            var result = new PalindromeChecker().IsPalindrome(String.Empty);
            // assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("at")]
        [InlineData("Test")]
        [InlineData("No way")]
        public void NonPalindrome(string value)
        {
            // act
            var result = new PalindromeChecker().IsPalindrome(value);
            // assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("oo")]
        [InlineData("mom")]
        [InlineData("Anna")]
        [InlineData("Live evil")]
        [InlineData("a man a plan a canal panama")]
        public void IsPalindrome(string value)
        {
            // act
            var result = new PalindromeChecker().IsPalindrome(value);
            // assert
            Assert.True(result);
        }
    }
}
