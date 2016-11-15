using Xunit;
using SimplerParser.Core;
using System;
using System.Collections.Generic;

namespace Tests 
{
    public class Scanner_EnumerationTests 
    {

        [Fact]
        public void Scanner_EnumerateCharacters() 
        {
            using (var sut = new Scanner("This is a Test")) {
                IEnumerator<Lexeme> e = sut.GetEnumerator();
                e.MoveNext();
                Assert.Equal('T', e.Current.Character); e.MoveNext();
                Assert.Equal('h', e.Current.Character); e.MoveNext();
                Assert.Equal('i', e.Current.Character); e.MoveNext();
                Assert.Equal('s', e.Current.Character); e.MoveNext();
                Assert.Equal(' ', e.Current.Character); e.MoveNext();
                Assert.Equal('i', e.Current.Character); e.MoveNext();
                Assert.Equal('s', e.Current.Character); e.MoveNext();
                Assert.Equal(' ', e.Current.Character); e.MoveNext();
                Assert.Equal('a', e.Current.Character); e.MoveNext();
                Assert.Equal(' ', e.Current.Character); e.MoveNext();
                Assert.Equal('T', e.Current.Character); e.MoveNext();
                Assert.Equal('e', e.Current.Character); e.MoveNext();
                Assert.Equal('s', e.Current.Character); e.MoveNext();
                Assert.Equal('t', e.Current.Character); 
                Assert.False(e.MoveNext());
                //Assert.Equal('t', e.Current.Character); e.MoveNext();
            }
        }


        [Fact]
        public void Scanner_ForEach() 
        {
            using (var sut = new Scanner("Test")) {
                var i = 0;

                foreach(var lex in sut) {
                    if (i == 0) { Assert.Equal('T', lex.Character); i++; continue; }
                    if (i == 1) { Assert.Equal('e', lex.Character); i++; continue;}
                    if (i == 2) { Assert.Equal('s', lex.Character); i++; continue;}
                    if (i == 3) { Assert.Equal('t', lex.Character); i++; continue;}
                }
            }
        }

        [Fact]
        public void Scanner_ForEach_TestIndex() {
            using (var sut = new Scanner("Test")) {
                var i = 0;

                foreach (var lex in sut) {
                    Assert.Equal(i, lex.Index);
                    i++;
                }
            }
        }

        [Fact]
        public void Scanner_ForEach_TestColumnsSimple() {
            using (var sut = new Scanner("Test")) {
                var i = 1;

                foreach (var lex in sut) {
                    Assert.Equal(i, lex.Column);
                    i++;
                }
            }
        }

        [Fact]
        public void Scanner_ForEach_LineTest() {
            using (var sut = new Scanner("Test\nTest")) {
                var i = 0;

                foreach (var lex in sut) {
                    if (i > 4) {
                        Assert.Equal(2, lex.Line);
                    } else {
                        Assert.Equal(1, lex.Line);
                    }

                    i++;
                }
            }
        }

    }
}