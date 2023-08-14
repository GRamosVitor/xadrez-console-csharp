using System;
using board;
using chess;

namespace xadrez_console {
    internal class Program {
        static void Main(string[] args) {
            ChessPosition pos = new ChessPosition('a', 1);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosition());
        }
    }
}
