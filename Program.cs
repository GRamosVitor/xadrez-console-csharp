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
                    Console.WriteLine();


                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();


                    bool[,] possiblePositions = match.board.piece(origin).possibleMovements();


                    Screen.printBoard(match.board, possiblePositions);


                    Console.Write("Destiny: ");
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
