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
    }
}
