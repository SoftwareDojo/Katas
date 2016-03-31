using CSharpKatas.ROT13;
using NUnit.Framework;

namespace CSharpKataTests.ROT13
{
    [TestFixture]
    public class Rot13Test
    {
        [TestCase("Hello World", "uryyb jbeyq")]
        public void Encode(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13();

            // act
            string actual = rot13.Encode(text);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("uryyb jbeyq", "hello world")]
        public void Decode(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13();

            // act
            string actual = rot13.Decode(text);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
