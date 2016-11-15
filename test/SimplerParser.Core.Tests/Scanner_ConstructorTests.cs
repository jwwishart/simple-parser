using Xunit;
using SimplerParser.Core;
using System;

namespace Tests
{
    public class Scanner_ConstructorTests
    {
        [Fact]
        public void Scanner_ConstructionNullString_IndicatesScannerEof() 
        {
            var sut = new Scanner(null);
            Assert.True(sut.IsEof);
        }

        [Fact]
        public void Scanner_ConstructionEmptyString_IndicatesScannerEof() 
        {
            var sut = new Scanner(String.Empty);
            Assert.True(sut.IsEof);
        }

        [Fact]
        public void Scanner_ConstructionWithString_ScansCorrectly() 
        {
            var content = "This is a test";
            var sut = new Scanner(content);
            Assert.False(sut.IsEof);
        }
    }
}
