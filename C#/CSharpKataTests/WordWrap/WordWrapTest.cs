using NUnit.Framework;

namespace CSharpKataTests.WordWrap
{
    [TestFixture]
    public class WrapTest
    {
        [TestCase("zeile1 zeile2", "zeile1\nzeile2", 0)]
        [TestCase("zeile1 zeile2", "zeile1\nzeile2", 7)]
        [TestCase("zeile1 zeile2", "zeile1\nzeile2", 12)]
        [TestCase("Let's Go outside.", "Let's Go\noutside.", 8)]
        [TestCase("Let's Go outside.", "Let's Go\noutside.", 15)]
        [TestCase("Let's Go outside.", "Let's Go\noutside.", 16)]
        [TestCase("Let's Go outside.", "Let's Go outside.", 17)]
        [TestCase("Let's Go outside.", "Let's Go outside.", 18)]
        [TestCase("Let's Go outside.", "Let's Go outside.", 50)]
        public void Wrap(string value, string expected, int lineLength)
        {
            // arrange
            var ww = new CSharpKatas.WordWrap.WordWrap();

            // act
            var actual = ww.Wrap(value, lineLength);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
