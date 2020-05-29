using Xunit;

namespace KatasTests.Palindrome
{
    public class PalindromeTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Empty_phrase_is_not_a_Palindrome(string phrase)
        {
            Assert.False(Katas.Palindrome.Palindrome.IsValid(phrase));
        }

        [Theory]
        [InlineData("at")]
        [InlineData("Test")]
        [InlineData("No way")]
        public void Phrase_is_not_a_Palindrome(string phrase)
        {
            Assert.False(Katas.Palindrome.Palindrome.IsValid(phrase));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("oo")]
        [InlineData("mom")]
        [InlineData("Anna")]
        [InlineData("Live evil")]
        [InlineData("a man a plan a canal panama")]
        public void Phrase_is_a_Palindrome(string phrase)
        {
            Assert.True(Katas.Palindrome.Palindrome.IsValid(phrase));
        }
    }
}
