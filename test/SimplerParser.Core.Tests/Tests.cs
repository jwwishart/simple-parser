using Xunit;
using SimplerParser.Core;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Tokenizer_Tests() 
        {
            Assert.NotNull(Lexer.Lex(string.Empty).First());
        }
    }
}
