using System;
using board;
using chess;

namespace xadrez_console {
    internal class Program {
        static void Main(string[] args) {
            Board board = new Board(8, 8);

            board.insertPiece(new Tower(board, Color.Preta), new Position(0, 0));
            board.insertPiece(new Tower(board, Color.Preta), new Position(1, 3));
            board.insertPiece(new King(board, Color.Preta), new Position(2, 4));

            Screen.printBoard(board);

            Console.WriteLine();
        }
    }
}
