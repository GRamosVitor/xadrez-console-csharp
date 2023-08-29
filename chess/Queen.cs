using board;

namespace chess {
    internal class Queen : Piece {
        
        public Queen (Board board, Color color) : base (board, color) {
        }

        public override string ToString() {
            return "Q";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.lines, board.colums];

            Position pos = new Position(0, 0);

            //up movement
            pos.defineValues(position.line - 1, position.colum);
            while (board.validPosition(pos) && canMove(pos)) {
                if (board.validPosition(pos) && canMove(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(pos.line - 1, pos.colum);
            }

            //superior right diagonal movement
            pos.defineValues(position.line - 1, position.colum + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                if (board.validPosition(pos) && canMove(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(pos.line - 1, pos.colum + 1);
            }
            //right position
            pos.defineValues(position.line, position.colum + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                if (board.validPosition(pos) && canMove(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(pos.line, pos.colum + 1);
            }

            //inferior right diagonal movement
            pos.defineValues(position.line + 1, position.colum + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                if (board.validPosition(pos) && canMove(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(pos.line + 1, pos.colum + 1);
            }

            //down movement
            pos.defineValues(position.line + 1, position.colum);
            while (board.validPosition(pos) && canMove(pos)) {
                if (board.validPosition(pos) && canMove(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(pos.line + 1, pos.colum);
            }

            //inferior left diagonal movement
            pos.defineValues(position.line + 1, position.colum - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                if (board.validPosition(pos) && canMove(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(pos.line + 1, pos.colum - 1);
            }

            //left movement
            pos.defineValues(position.line, position.colum - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                if (board.validPosition(pos) && canMove(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(pos.line, pos.colum - 1);
            }

            //superior left diagonal movement
            pos.defineValues(position.line - 1, position.colum - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                if (board.validPosition(pos) && canMove(pos)) {
                    mat[pos.line, pos.colum] = true;
                }
                pos.defineValues(pos.line - 1, pos.colum - 1);
            }

            return mat;
        }
    }
}
