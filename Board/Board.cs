using xadrez_console;

namespace board {
    internal class Board {
        public int lines { get; set; }
        public int colums { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int colums) {
            this.lines = lines;
            this.colums = colums;
            pieces = new Piece[lines, colums];
        }

        public Piece piece(int line, int colums) {
            return pieces[line, colums];
        }

        public Piece piece (Position pos) {
            return pieces[pos.line, pos.colum];
        }

        public void insertPiece(Piece p, Position pos) {
            if (pieceExistInPosition(pos)) {
                throw new BoardException("There already is another piece in this position!");
            }
            pieces[pos.line, pos.colum] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos) {
            if (piece(pos) == null) {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.line, pos.colum] = null;
            return aux;
        }

        public bool pieceExistInPosition(Position pos) {
            validatePosition(pos);
            return piece(pos) != null;
        }
        public bool validPosition(Position pos) {
            if (pos.line<0 || pos.line>=lines || pos.colum<0 || pos.colum>= colums) {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos) {
            if (!validPosition(pos)) {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
