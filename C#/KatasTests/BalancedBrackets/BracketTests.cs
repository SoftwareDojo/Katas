using System;
using Katas.BalancedBrackets;
using Xunit;

namespace KatasTests.BalancedBrackets
{
    public class Bracket_is_balanced
    {
        [Theory]
        [InlineData("()")]
        [InlineData("{}")]
        [InlineData("[]")]
        [InlineData("()()")]
        [InlineData("(){}")]
        [InlineData("(){}[]")]
        [InlineData("(()())")]
        [InlineData("({}[])")]
        public void if_all_brackets_are_balanced(string text)
        {
            Assert.True(new Text(text).BracketsBalanced());
        }

        [Theory]
        [InlineData("(())")]
        [InlineData("{()}")]
        [InlineData("{([])}")]
        [InlineData("((((()))))")]
        [InlineData("{{{{{}}}}}")]
        [InlineData("[[[[[]]]]]")]
        public void if_all_nested_bracket_is_balanced(string text)
        {
            Assert.True(new Text(text).BracketsBalanced());
        }
    }

    public class Bracket_is_not_balanced
    {
        [Theory]
        [InlineData("(")]
        [InlineData("{")]
        [InlineData("[")]
        [InlineData(")")]
        [InlineData("}")]
        [InlineData("]")]
        [InlineData("())")]
        [InlineData("()}")]
        [InlineData("()]")]
        [InlineData("()(")]
        [InlineData("(){")]
        [InlineData("()[")]
        [InlineData("(()")]
        [InlineData("{()")]
        [InlineData("[()")]
        public void if_close_or_open_is_missing(string text)
        {
            Assert.False(new Text(text).BracketsBalanced());
        }

        [Theory]
        [InlineData(")(")]
        [InlineData("}{")]
        [InlineData("][")]
        [InlineData("[]]()")]

        public void if_close_is_before_open(string text)
        {
            Assert.False(new Text(text).BracketsBalanced());
        }

        [Theory]
        [InlineData("(]()")]
        [InlineData("{()()]")]
        [InlineData("{([(}])}")]
        [InlineData("{()([(}])}")]
        public void if_a_wrong_close_or_open_is_used(string text)
        {
            Assert.False(new Text(text).BracketsBalanced());
        }
    }

    public class Text_is_not_supported
    {
        [Fact]
        public void if_the_text_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Text(null).BracketsBalanced());
        }

        [Fact]
        public void if_the_text_is_empty()
        {
            Assert.Throws<ArgumentNullException>(() => new Text(string.Empty).BracketsBalanced());
        }

        [Fact]
        public void if_the_text_contains_only_whitespaces()
        {
            Assert.Throws<ArgumentNullException>(() => new Text("    ").BracketsBalanced());
        }
    }
}
