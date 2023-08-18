using System;
using System.Security.Cryptography.X509Certificates;
using board;
using chess;


namespace xadrez_console {
    internal class Screen {

        public static void printBoard(Board board) {
            for (int i = 0; i < board.lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.colums; j++) {

                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possiblePositions) {
            ConsoleColor originalBkgd = Console.BackgroundColor;
            ConsoleColor newBkgd = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.colums; j++) {
                    if (possiblePositions[i, j]) {
                        Console.BackgroundColor = newBkgd;
                    } else {
                        Console.BackgroundColor = originalBkgd;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBkgd;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBkgd;
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new ChessPosition(coluna, linha);
        }

        public static void printPiece(Piece piece) {
            if (piece == null) {
                Console.Write("- ");
            } else {

                if (piece.color == Color.White) {
                    Console.Write(piece);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
