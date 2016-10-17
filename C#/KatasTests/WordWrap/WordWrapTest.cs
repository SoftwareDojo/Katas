using Xunit;

namespace KatasTests.WordWrap
{
    public class WrapTest
    {
        [Theory]
        [InlineData("zeile1 zeile2", "zeile1\nzeile2", 0)]
        [InlineData("zeile1 zeile2", "zeile1\nzeile2", 7)]
        [InlineData("zeile1 zeile2", "zeile1\nzeile2", 12)]
        [InlineData("Let's Go outside.", "Let's Go\noutside.", 8)]
        [InlineData("Let's Go outside.", "Let's Go\noutside.", 15)]
        [InlineData("Let's Go outside.", "Let's Go\noutside.", 16)]
        [InlineData("Let's Go outside.", "Let's Go outside.", 17)]
        [InlineData("Let's Go outside.", "Let's Go outside.", 18)]
        [InlineData("Let's Go outside.", "Let's Go outside.", 50)]
        public void Wrap(string value, string expected, int lineLength)
        {
            // arrange
            var ww = new Katas.WordWrap.WordWrap();

            // act
            var actual = ww.Wrap(value, lineLength);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
