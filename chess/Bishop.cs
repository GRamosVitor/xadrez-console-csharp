﻿using board;

namespace chess {
    internal class Bishop : Piece {
        
        public Bishop (Board board, Color color) : base (board, color) {
        }

        public override string ToString() {
            return "B";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.lines, board.colums];

            Position pos = new Position(0, 0);
        
            //NO
            pos.defineValues(position.line - 1, position.colum-1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line - 1, pos.colum-1);
            }

            //NE
            pos.defineValues(position.line - 1, position.colum + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line - 1, pos.colum + 1);
            }

            //SO
            pos.defineValues(position.line + 1, position.colum - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line + 1, pos.colum - 1);
            }

            //SE
            pos.defineValues(position.line + 1, position.colum + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.line + 1, pos.colum + 1);
            }
            return mat;
        }
    }
}
