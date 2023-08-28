using System;
using board;

namespace xadrez_console.chess {
    internal class Pawn : Piece {

        public Pawn(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "P";
        }

        private bool existsEnemy(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos) {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.lines, board.colums];

            Position pos = new Position(0, 0);

            if(color == Color.White) {
                pos.defineValues(position.line - 1, position.colum);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line - 2, position.colum);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line - 1, position.colum-1);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line - 1, position.colum+1);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
            } else {
                pos.defineValues(position.line + 1, position.colum);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line + 2, position.colum);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line + 1, position.colum-1);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line + 1, position.colum+1);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
            }

            return mat;

        } 

    }
}
