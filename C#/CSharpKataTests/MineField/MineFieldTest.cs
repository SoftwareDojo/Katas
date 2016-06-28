using CSharpKatas.MineField;
using NUnit.Framework;

namespace CSharpKataTests.MineFieldTest
{
    [TestFixture]
    public class MineFieldTest
    {
        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase(".", "0")]
        [TestCase("....", "0000")]
        public void No_Mines_Single_Line(string mines, string expected)
        {
            AssertHint(mines, expected);
        }

        [TestCase(".;.", "0;0")]
        [TestCase("....;....;....;....", "0000;0000;0000;0000")]
        public void No_Mines_Multiple_Lines(string mines, string expected)
        {
            AssertHint(mines, expected);
        }

        [TestCase("*", "*")]
        [TestCase("****", "****")]
        public void Mines_Single_Line(string mines, string expected)
        {
            AssertHint(mines, expected);
        }

        [TestCase("*;*", "*;*")]
        [TestCase("****;****;****;****", "****;****;****;****")]
        public void Mines_Multiple_Lines(string mines, string expected)
        {
            AssertHint(mines, expected);
        }

        [TestCase("*.","*1")]
        [TestCase("*..", "*10")]
        [TestCase("*...", "*100")]
        [TestCase(".*", "1*")]
        [TestCase("..*", "01*")]
        [TestCase("...*", "001*")]
        [TestCase(".*.", "1*1")]
        [TestCase("..*..", "01*10")]
        [TestCase(".**.", "1**1")]
        public void One_Mine_In_Simple_Line(string mines, string expected)
        {
            AssertHint(mines, expected);
        }

        [TestCase("*.*", "*2*")]
        [TestCase("**.*", "**2*")]
        [TestCase(".**.*.", "1**2*1")]
        public void Multiple_Mines_In_Simple_Line(string mines, string expected)
        {
            AssertHint(mines, expected);
        }

        [TestCase("*;.", "*;1")]
        [TestCase("*;.;.", "*;1;0")]
        [TestCase(".;*", "1;*")]
        [TestCase(".;.;*", "0;1;*")]
        [TestCase("*.;..", "*1;11")]
        [TestCase(".*;..", "1*;11")]
        [TestCase("..;.*", "11;1*")]
        [TestCase("..;*.", "11;*1")]
        [TestCase("...;.*.;...", "111;1*1;111")]
        public void One_Mine_In_Multiple_Lines(string mines, string expected)
        {
            AssertHint(mines, expected);
        }

        [TestCase("*...;....;.*..;....", "*100;2210;1*10;1110")]
        [TestCase("*.*.;.*.*;*.*.;.*.*", "*3*2;3*4*;*4*3;2*3*")]
        public void Multiple_Mines_In_Multiple_Lines(string mines, string expected)
        {
            AssertHint(mines, expected);
        }

        private void AssertHint(string mines, string expected)
        {
            var mineFiled = new MineField();
            var actual = mineFiled.CreateHint(mines);

            Assert.AreEqual(expected, actual);
        }
    }
}
