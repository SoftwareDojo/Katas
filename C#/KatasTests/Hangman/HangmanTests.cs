using Katas.Hangman;

using Xunit;

namespace KatasTests.Hangman
{
    public class HangmanTests
    {
        [Fact]
        public void Initial_Result()
        {
            // arrange
            var word = "Test";
            var hangman = new Katas.Hangman.Hangman(word);

            // act
            var actual = hangman.Result;

            // assert
            Assert.Equal("----", actual);
        }

        [Fact]
        public void Guess_Wrong()
        {
            // arrange
            var hangman = new Katas.Hangman.Hangman("Test");

            // act
            var result = hangman.Guess('u');

            // assert
            Assert.False(result);
            Assert.Equal("----", hangman.Result);
        }

        [Theory]
        [InlineData('e', "-e--")]
        [InlineData('T', "T--t")]
        [InlineData('t', "T--t")]
        public void Guess_Rigth(char guess, string expected)
        {
            // arrange
            var hangman = new Katas.Hangman.Hangman("Test");

            // act
            var result = hangman.Guess(guess);

            // assert
            Assert.True(result);
            Assert.Equal(expected, hangman.Result);
        }

        [Fact]
        public void Guess_Chances()
        {
            // arrange
            var maxChances = 1;
            var hangman = new Katas.Hangman.Hangman("Test", maxChances);

            // act & assert
            hangman.Guess('a');
            hangman.Guess('e');
            Assert.Throws<HangmanException>(() => hangman.Guess('i'));
        }
    }
}
