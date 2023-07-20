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
            Assert.Equal(expected, new Rot13().Encode(text));
        }

        [Theory]
        [InlineData("Hello World", "Ifmmp Xpsme")]
        [InlineData("ABC", "BCD")]
        [InlineData("xyz", "yza")]
        public void Encode_offset_1(string text, string expected)
        {
            Assert.Equal(expected, new Rot13(1).Encode(text));
        }

        [Theory]
        [InlineData("München", "Zhrapura")]
        [InlineData("Köln", "Xbrya")]
        public void Encode_with_german_characters(string text, string expected)
        {
            Assert.Equal(expected, new Rot13().Encode(text));
        }

        [Theory]
        [InlineData("Uryyb Jbeyq!", "Hello World!")]
        [InlineData("nop", "abc")]
        [InlineData("klm", "xyz")]
        public void Decode(string text, string expected)
        {
            Assert.Equal(expected, new Rot13().Decode(text));
        }

        [Theory]
        [InlineData("Ifmmp Xpsme!", "Hello World!")]
        [InlineData("bcd", "abc")]
        [InlineData("yza", "xyz")]
        public void Decode_offset_1(string text, string expected)
        {
            Assert.Equal(expected, new Rot13(1).Decode(text));
        }
    }
}
