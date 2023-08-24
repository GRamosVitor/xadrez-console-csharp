using System;
using board;
using System.Collections.Generic;

namespace chess {
    internal class ChessMatch {
        
        public Board board { get; set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured; 

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPieces();
        }

        public void performMovement (Position origin, Position target) {
            Piece p = board.removePiece(origin);
            p.incrementMovimentQtt();
            Piece capturedPiece = board.removePiece(target);
            board.insertPiece(p, target);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> capturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
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

        public void insertNewPiece(char colum, int line, Piece piece) {
            board.insertPiece(piece, new ChessPosition(colum, line).toPosition());
            pieces.Add(piece);
        }

        private void insertPieces() {
            insertNewPiece('c', 1, new Tower(board, Color.White));
            insertNewPiece('c', 2, new Tower(board, Color.White));
            insertNewPiece('d', 2, new Tower(board, Color.White));
            insertNewPiece('e', 2, new Tower(board, Color.White));
            insertNewPiece('e', 1, new Tower(board, Color.White));
            insertNewPiece('d', 1, new King(board, Color.White));

            insertNewPiece('c', 7, new Tower(board, Color.Black));
            insertNewPiece('c', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 7, new Tower(board, Color.Black));
            insertNewPiece('e', 7, new Tower(board, Color.Black));
            insertNewPiece('e', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 8, new King(board, Color.Black));

        }
    }
}
