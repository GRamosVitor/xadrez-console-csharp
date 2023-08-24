using board;

namespace chess {
    internal class Tower : Piece {

        public Tower(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "T";
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
                mat[pos.line, pos.colum] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.line = pos.line - 1;
            }

            //right position
            pos.defineValues(position.line, position.colum + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.colum = pos.colum + 1;
            }


            //down movement
            pos.defineValues(position.line + 1, position.colum);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.line = pos.line + 1;
            }

            //left movement
            pos.defineValues(position.line, position.colum - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.colum] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.colum = pos.colum - 1;
            }

            return mat;
        }
    }
}
