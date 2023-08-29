using System;
using board;
using chess;

namespace xadrez_console.chess {
    internal class Pawn : Piece {
        
        private ChessMatch match;

        public Pawn(Board board, Color color, ChessMatch match) : base(board, color) {
            this.match = match;
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
                if (board.validPosition(pos) && free(pos) && moveQtt == 0) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line - 1, position.colum - 1);
                if (board.validPosition(pos) && existsEnemy(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line - 1, position.colum + 1);
                if (board.validPosition(pos) && free(pos) && existsEnemy(pos)) {
                    mat[pos.line, pos.colum] = true;
                }

                //Special move En Passsant
                if (position.line == 3) {
                    Position left = new Position(position.line, position.colum - 1);
                    if (board.validPosition(left) && existsEnemy(left) && board.piece(left) == match.enPassantVulnerable) {
                        mat[left.line - 1, left.colum] |= true;
                    }
                }
                //Special move En Passsant
                if (position.line == 3) {
                    Position right = new Position(position.line, position.colum + 1);
                    if (board.validPosition(right) && existsEnemy(right) && board.piece(right) == match.enPassantVulnerable) {
                        mat[right.line - 1, right.colum] |= true;
                    }
                }
            } else {
                pos.defineValues(position.line + 1, position.colum);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line + 2, position.colum);
                if (board.validPosition(pos) && free(pos) && moveQtt == 0) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line + 1, position.colum - 1);
                if (board.validPosition(pos) && free(pos) && existsEnemy(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(position.line + 1, position.colum + 1);
                if (board.validPosition(pos) && free(pos) && existsEnemy(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                //Special move En Passsant
                if (position.line == 4) {
                    Position left = new Position(position.line, position.colum - 1);
                    if (board.validPosition(left) && existsEnemy(left) && board.piece(left) == match.enPassantVulnerable) {
                        mat[left.line + 1, left.colum] |= true;
                    }
                }
                //Special move En Passsant
                if (position.line == 4) {
                    Position right = new Position(position.line, position.colum + 1);
                    if (board.validPosition(right) && existsEnemy(right) && board.piece(right) == match.enPassantVulnerable) {
                        mat[right.line + 1, right.colum] |= true;
                    }
                }

            }

            return mat;

        } 

    }
}
