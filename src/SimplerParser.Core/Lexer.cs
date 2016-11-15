
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SimplerParser.Core
{
    public class Lexeme {
        public char Character { get; set; }
        public int Index { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    /// <summary>
    /// The Scanner simply provides the ability to take some sort of stream or string
    /// and return a character at a time for a tokenizer and or parser to then consider
    /// </summary>
    public class Scanner : IDisposable, IEnumerable<Lexeme>
    {
        public bool IsEof {get; private set;}
        private TextReader Reader {get; set;} = null;

        public Scanner(string content) 
        {
            // Invariants
            if (String.IsNullOrWhiteSpace(content)) 
            {
                IsEof = true;
                return;
            }

            Reader = new StringReader(content);
        }

        private void SetupReader(string content) 
        {
            Reader = new StringReader(content);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    Reader?.Dispose();
                }

                // Set large fields to null.
                Reader = null;

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        public IEnumerator<Lexeme> GetEnumerator()
        {
            int character = -1;
            int index = 0;
            int line = 1;
            int column = 1;

            while ((character = Reader.Read()) != -1) 
            {
                // TODO: normalize newlines if configured to do so
                // TODO: correctly calculate lines etc.
                yield return new Lexeme{
                    Character = (char)character,
                    Index = index++,
                    Line = line,
                    Column = column++,
                };

                if ('\n' == (char)character) {
                    line++;
                }
            }

            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }

}
