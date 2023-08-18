using System;
using board;

namespace chess {
    internal class ChessMatch {
        
        public Board board { get; set; }
        private int turn;
        private Color currentPlayer;
        public bool finished { get; set; }

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            insertPieces();
        }

        public void performMovement (Position origin, Position target) {
            Piece p = board.removePiece(origin);
            p.incrementMovimentQtt();
            Piece capturedPiece = board.removePiece(target);
            board.insertPiece(p, target);
        }

        private void insertPieces() {
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.insertPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.insertPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
