using CSharpKatas.ROT13;
using NUnit.Framework;

namespace CSharpKataTests.ROT13
{
    [TestFixture]
    public class Rot13Test
    {
        [TestCase("Hello World!", "Uryyb Jbeyq!")]
        [TestCase("ABC", "NOP")]
        [TestCase("xyz", "klm")]
        public void Encode(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13();

            // act
            string actual = rot13.Encode(text);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello World", "Ifmmp Xpsme")]
        [TestCase("ABC", "BCD")]
        [TestCase("xyz", "yza")]
        public void Encode_offset_1(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13(1);

            // act
            string actual = rot13.Encode(text);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("München", "Zhrapura")]
        [TestCase("Köln", "Xbrya")]
        public void Encode_with_german_characters(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13();

            // act
            string actual = rot13.Encode(text);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Uryyb Jbeyq!", "Hello World!")]
        [TestCase("nop", "abc")]
        [TestCase("klm", "xyz")]
        public void Decode(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13();

            // act
            string actual = rot13.Decode(text);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Ifmmp Xpsme!", "Hello World!")]
        [TestCase("bcd", "abc")]
        [TestCase("yza", "xyz")]
        public void Decode_offset_1(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13(1);

            // act
            string actual = rot13.Decode(text);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
