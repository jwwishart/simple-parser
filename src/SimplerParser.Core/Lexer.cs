
using System.Collections.Generic;

namespace SimplerParser.Core
{

    public enum TokenType {
        Unknown,
        Number,
        Operator,
    }

    public class Token {
        public TokenType Type { get; set;} = TokenType.Unknown;
        public string Content { get; set; } = string.Empty;
    }

    public class Lexer {
        
        public static IEnumerable<Token> Lex(string toLex) {
            yield return new Token();
        } 
    }
}
