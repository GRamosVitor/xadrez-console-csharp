using System.Runtime.Remoting.Messaging;

namespace board {
    internal abstract class Piece {
        public Position position {  get; set; }
        public Color color { get; protected set; }
        public int moveQtt { get; protected set; }
        public Board board { get; protected set; }

        public Piece (Board board, Color color) {
            this.position = null;
            this.board = board;
            this.color = color;
            this.moveQtt = 0;
        }

        public void incrementMovimentQtt() { 
            moveQtt = 1; 
        }

        public abstract bool[,] possibleMovements();

        public bool possibleMovementsExist() {
            bool[,] mat = possibleMovements();
            for (int i=0; i<board.lines; i++) {
                for (int j=0; j<board.colums; j++) {
                    if (mat[i,j]) {
                        return true;
                    }
                }
            } return false;
        }

        public bool canMoveTo(Position pos) {
            return possibleMovements()[pos.line, pos.colum];
        }

        protected bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

    }
}
