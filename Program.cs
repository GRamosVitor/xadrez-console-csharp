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
                    try {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validadeOriginPosition(origin);

                        bool[,] possiblePositions = match.board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.printBoard(match.board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        
                        match.validadeTargetPosition(origin, destiny);

                        match.performsMove(origin, destiny);

                        Screen.printBoard(match.board);
                        Console.WriteLine();

                    } catch (BoardException e) {
                        Console.WriteLine("Error: " + e.Message);
                        Console.ReadLine();
                    }
                }

            } catch (BoardException e) {
                Console.WriteLine("Error: " + e.Message);

            }
        }
    }
}
