using Xunit;
using Katas.ROT13;

namespace KatasTests.ROT13
{
    public class Rot13Test
    {
        [Theory]
        [InlineData("Hello World!", "Uryyb Jbeyq!")]
        [InlineData("ABC", "NOP")]
        [InlineData("xyz", "klm")]
        public void Encode(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13();

            // act
            string actual = rot13.Encode(text);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hello World", "Ifmmp Xpsme")]
        [InlineData("ABC", "BCD")]
        [InlineData("xyz", "yza")]
        public void Encode_offset_1(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13(1);

            // act
            string actual = rot13.Encode(text);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("München", "Zhrapura")]
        [InlineData("Köln", "Xbrya")]
        public void Encode_with_german_characters(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13();

            // act
            string actual = rot13.Encode(text);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Uryyb Jbeyq!", "Hello World!")]
        [InlineData("nop", "abc")]
        [InlineData("klm", "xyz")]
        public void Decode(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13();

            // act
            string actual = rot13.Decode(text);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Ifmmp Xpsme!", "Hello World!")]
        [InlineData("bcd", "abc")]
        [InlineData("yza", "xyz")]
        public void Decode_offset_1(string text, string expected)
        {
            // arrange
            var rot13 = new Rot13(1);

            // act
            string actual = rot13.Decode(text);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
