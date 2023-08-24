using System;
using board;

namespace chess {
    internal class ChessMatch {
        
        public Board board { get; set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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

        public void performsMove(Position origin, Position target) {
            performMovement(origin, target);
            turn++;
            changePlayer();
        }

        private void changePlayer() {
            if (currentPlayer == Color.White) {
            currentPlayer = Color.Black;
            } else {
                currentPlayer = Color.White;
            }
        }

        public void validadeOriginPosition(Position pos) {
            if (board.piece(pos) == null) {
                throw new BoardException("There is no piece on chosen position");
            }
            if (currentPlayer != board.piece(pos).color) {
                throw new BoardException("The chosen piece is not yours");
            }
            if (!board.piece(pos).possibleMovementsExist()) {
                throw new BoardException("There are no possible movements for chosen piece");
            }
        }

        public void validadeTargetPosition(Position origin, Position destiny) {
            if (!board.piece(origin).canMoveTo(destiny)) {
                throw new BoardException("Invalid target position");
            }
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
