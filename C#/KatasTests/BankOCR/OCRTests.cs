using System;
using System.Linq;
using Katas.BankOCR;
using Xunit;

namespace KatasTests.BankOCR
{
    public class OCRTests
    {
        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("7")]
        [InlineData("8")]
        [InlineData("9")]
        public void Read_Digit(string expected)
        {
            // arrange
            var text = GetOcrFromDigits(expected);
            // act
            var actual = new OCR().ReadText(text);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("11111")]
        [InlineData("989898")]
        [InlineData("12345")]
        [InlineData("0831579624")]
        public void Read_Line(string expected)
        {
            // arrange
            var text = GetOcrFromDigits(expected);
            // act
            var actual = new OCR().ReadText(text);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1;2;3;4;5")]
        [InlineData("081;32;476;5059;1")]
        public void Read_Text(string expected)
        {
            //arrange
            var lines = expected.Split(new[] { ';' }, StringSplitOptions.None);
            var text = lines.Aggregate(string.Empty, (current, line) => current + GetOcrFromDigits(line));

            // act
            var actual = new OCR().ReadText(text);
            // assert
            Assert.Equal(expected.Replace(";", Environment.NewLine), actual);
        }

        private string GetOcrFromDigits(string value)
        {
            var digits = new Digits();
            var result = string.Empty;
            var numbers = value.Select(c => int.Parse(c.ToString())).ToArray();
            for (var i = 0; i < 3; i++)
            {
                foreach (var num in numbers)
                {
                    result += digits[num].Lines[i];
                }

                result += Environment.NewLine;
            }

            return result;
        }
    }
}
