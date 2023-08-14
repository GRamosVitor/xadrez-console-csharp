

using System;

namespace board {
    internal class BoardException : ApplicationException {
        public BoardException(string msg) : base(msg) { }
    }
}
