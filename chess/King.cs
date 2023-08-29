using board;

namespace chess {
    internal class King : Piece {
        private ChessMatch match;
        
        public King (Board board, Color color, ChessMatch match) : base (board, color) {
            this.match = match;
        }

        public override string ToString() {
            return "K";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        private bool testRookForCastle(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && moveQtt == 0;
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
            pos.defineValues(position.line + 1, position.colum + 1);
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

            //#special move castle
            if(moveQtt==0 && !match.check) {
                //small castle
                Position posR1 = new Position (position.line, position.colum + 3);
                if (testRookForCastle(posR1)) {
                    Position p1 = new Position(position.line, position.colum + 1);
                    Position p2 = new Position(position.line, position.colum + 2);
                    if(board.piece(p1) == null && board.piece(p2) == null) {
                        mat[position.line, position.colum + 2] = true;
                    }
                }

                //big castle
                Position posR2 = new Position(position.line, position.colum - 4);
                if (testRookForCastle(posR2)) {
                    Position p1 = new Position(position.line, position.colum - 1);
                    Position p2 = new Position(position.line, position.colum - 2);
                    Position p3 = new Position(position.line, position.colum - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null) {
                        mat[position.line, position.colum - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
