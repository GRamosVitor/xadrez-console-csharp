using board;

namespace chess {
    internal class Knight : Piece {
        
        public Knight (Board board, Color color) : base (board, color) {
        }

        public override string ToString() {
            return "N";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.lines, board.colums];

            Position pos = new Position(0, 0);
           
            //left-up
            pos.defineValues(position.line - 1, position.colum-2);
            if(board.validPosition(pos) && canMove(pos) ) {
                mat[pos.line, pos.colum] = true;
            }

            //up-left
            pos.defineValues(position.line - 2, position.colum - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //right-up
            pos.defineValues(position.line - 2, position.colum + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //up-right
            pos.defineValues(position.line - 1, position.colum +2);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //left-down
            pos.defineValues(position.line + 1, position.colum - 2);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //dowm-left
            pos.defineValues(position.line + 2, position.colum - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //left-up
            pos.defineValues(position.line + 2, position.colum + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            //up-left
            pos.defineValues(position.line + 1, position.colum + 2);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
            }

            return mat;
        }
    }
}
