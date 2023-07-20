using Katas;
using Xunit;

namespace KatasTests
{
    public class MineFieldTest
    {
        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData(".", "0")]
        [InlineData("....", "0000")]
        public void No_Mines_Single_Line(string mines, string expected)
        {
            Assert.Equal(expected, MineField.CreateHint(mines));
        }

        [Theory]
        [InlineData(".;.", "0;0")]
        [InlineData("....;....;....;....", "0000;0000;0000;0000")]
        public void No_Mines_Multiple_Lines(string mines, string expected)
        {
            Assert.Equal(expected, MineField.CreateHint(mines));
        }

        [Theory]
        [InlineData("*", "*")]
        [InlineData("****", "****")]
        public void Mines_Single_Line(string mines, string expected)
        {
            Assert.Equal(expected, MineField.CreateHint(mines));
        }

        [Theory]
        [InlineData("*;*", "*;*")]
        [InlineData("****;****;****;****", "****;****;****;****")]
        public void Mines_Multiple_Lines(string mines, string expected)
        {
            Assert.Equal(expected, MineField.CreateHint(mines));
        }

        [Theory]
        [InlineData("*.", "*1")]
        [InlineData("*..", "*10")]
        [InlineData("*...", "*100")]
        [InlineData(".*", "1*")]
        [InlineData("..*", "01*")]
        [InlineData("...*", "001*")]
        [InlineData(".*.", "1*1")]
        [InlineData("..*..", "01*10")]
        [InlineData(".**.", "1**1")]
        public void One_Mine_In_Simple_Line(string mines, string expected)
        {
            Assert.Equal(expected, MineField.CreateHint(mines));
        }

        [Theory]
        [InlineData("*.*", "*2*")]
        [InlineData("**.*", "**2*")]
        [InlineData(".**.*.", "1**2*1")]
        public void Multiple_Mines_In_Simple_Line(string mines, string expected)
        {
            Assert.Equal(expected, MineField.CreateHint(mines));
        }

        [Theory]
        [InlineData("*;.", "*;1")]
        [InlineData("*;.;.", "*;1;0")]
        [InlineData(".;*", "1;*")]
        [InlineData(".;.;*", "0;1;*")]
        [InlineData("*.;..", "*1;11")]
        [InlineData(".*;..", "1*;11")]
        [InlineData("..;.*", "11;1*")]
        [InlineData("..;*.", "11;*1")]
        [InlineData("...;.*.;...", "111;1*1;111")]
        public void One_Mine_In_Multiple_Lines(string mines, string expected)
        {
            Assert.Equal(expected, MineField.CreateHint(mines));
        }

        [Theory]
        [InlineData("*...;....;.*..;....", "*100;2210;1*10;1110")]
        [InlineData("*.*.;.*.*;*.*.;.*.*", "*3*2;3*4*;*4*3;2*3*")]
        public void Multiple_Mines_In_Multiple_Lines(string mines, string expected)
        {
            Assert.Equal(expected, MineField.CreateHint(mines));
        }
    }
}
