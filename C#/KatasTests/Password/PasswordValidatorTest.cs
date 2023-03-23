using Katas.Password;
using Xunit;

namespace KatasTests.Password
{
    public class PasswordValidatorTest
    {
        [Theory]
        [InlineData("12345678")]
        [InlineData("")]
        public void A_password_should_have_more_than_8_characters(string password)
        {
            Assert.False(PasswordValidator.Validate(password));
        }

        [Theory]
        [InlineData("123456789#")]
        [InlineData("abcdefghij1#")]
        public void A_password_should_contains_a_capital_letter(string password)
        {
            Assert.False(PasswordValidator.Validate(password));
        }

        [Theory]
        [InlineData("123456789#")]
        [InlineData("ABCDEFGHIJ1#")]
        public void A_password_should_contains_a_lowercase_letter(string password)
        {
            Assert.False(PasswordValidator.Validate(password));
        }

        [Theory]
        [InlineData("AbCdEfGhIj#")]
        public void A_password_should_contains_a_digit(string password)
        {
            Assert.False(PasswordValidator.Validate(password));
        }

        [Theory]
        [InlineData("AbCdEfGhIj1")]
        public void A_password_should_contains_a_special_character(string password)
        {
            Assert.False(PasswordValidator.Validate(password));
        }

        [Theory]
        [InlineData("AbCdEfGhIj1#")]
        [InlineData("!2AbCdEfGhIj")]
        [InlineData("(AbCdEfGhIj3")]
        [InlineData("Abcde_12345")]
        public void A_complex_password_should_be_valid(string password)
        {
            Assert.True(PasswordValidator.Validate(password));
        }
    }
}