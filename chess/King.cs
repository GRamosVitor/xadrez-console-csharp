using board;

namespace chess {
    internal class King : Piece {
        
        public King (Board board, Color color) : base (board, color) {
        }

        public override string ToString() {
            return "K";
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
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //superior right diagonal movement
            pos.defineValues(position.line - 1, position.colum + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //right position
            pos.defineValues(position.line, position.colum + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //inferior right diagonal movement
            pos.defineValues(position.line - 1, position.colum + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //down movement
            pos.defineValues(position.line + 1, position.colum);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //inferior left diagonal movement
            pos.defineValues(position.line + 1, position.colum - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //left movement
            pos.defineValues(position.line, position.colum - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //superior left diagonal movement
            pos.defineValues(position.line - 1, position.colum - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            return mat;
        }
    }
}
