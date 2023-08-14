using System;
using board;
using chess;

namespace xadrez_console {
    internal class Program {
        static void Main(string[] args) {
            Board board = new Board(8, 8);
            try {
                board.insertPiece(new Tower(board, Color.Preta), new Position(0, 0));
                board.insertPiece(new Tower(board, Color.Preta), new Position(1, 3));
                board.insertPiece(new King(board, Color.Preta), new Position(2, 4));

                board.insertPiece(new Tower(board, Color.Branca), new Position(3, 5));

                Screen.printBoard(board);

                Console.WriteLine();
            } catch (BoardException e) {
                Console.WriteLine("Error: " + e.Message);
            }
          
        }
    }
}
