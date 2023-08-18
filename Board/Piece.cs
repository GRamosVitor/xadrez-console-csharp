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

    }
}
