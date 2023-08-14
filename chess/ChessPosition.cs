using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess {
    internal class ChessPosition {
        public char colum { get; set; }
        public int line { get; set; }

        public ChessPosition(char colum, int line) {
            this.colum = colum;
            this.line = line;
        }

        public Position toPosition() {
            return new Position(8 - line, colum - 'a');
        }
        public override string ToString() {
            return "" + colum + line;
        }
    }
}
