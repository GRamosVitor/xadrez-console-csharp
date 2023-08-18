using System;
using board;
using chess;

namespace xadrez_console {
    internal class Program {
        static void Main(string[] args) {
            Board board = new Board(8, 8);
            try {
                ChessMatch match = new ChessMatch();

                while (!match.finished) {
                    Console.Clear();
                    Screen.printBoard(match.board);


                    Console.WriteLine("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();
                    Console.WriteLine("Destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.performMovement(origin, destiny);
                }

                Screen.printBoard(match.board);

                Console.WriteLine();
            } catch (BoardException e) {
                Console.WriteLine("Error: " + e.Message);
            }
          
        }
    }
}
