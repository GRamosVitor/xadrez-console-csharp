using System;
using board;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text.RegularExpressions;
using xadrez_console;
using xadrez_console.chess;

namespace chess {
    internal class ChessMatch {
        
        public Board board { get; set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; } 

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPieces();
            check = false;
        }

        public Piece doMovement (Position origin, Position target) {
            Piece p = board.removePiece(origin);
            p.incrementMovimentQtt();
            Piece capturedPiece = board.removePiece(target);
            board.insertPiece(p, target);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMovement(Position origin, Position target, Piece capturedPiece) {
            Piece p = board.removePiece(target);
            p.decreaseMovimentQtt();
            if(capturedPiece != null) {
                board.insertPiece(capturedPiece, target);
                captured.Remove(capturedPiece);
            }
            board.insertPiece(p, origin);
        }

        public void performsMove(Position origin, Position target) {
            Piece capturedPiece = doMovement(origin, target);
            if (isInCheck(currentPlayer)) {
                undoMovement(origin, target, capturedPiece);
                throw new BoardException("You cannot put yourself in check");
            }
            if (isInCheck(oponnent(currentPlayer))) {
                check = true;
            } else {
                check = false;
            }
            if (checkmateTest(oponnent(currentPlayer))) {
                finished = true;
            }
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
            foreach (Piece x in pieces) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color oponnent(Color color) {
            if (color == Color.White) {
                return Color.Black;
            } else {
                return Color.White;
            }
        }

        private Piece king(Color color) {
            foreach (Piece x in piecesInGame(color)) {
                if (x is King) {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck (Color color) {
            Piece k = king(color);
            if (k == null) {
                throw new BoardException("There is not a " + color + " king on the board");
            }
            foreach (Piece x in piecesInGame(oponnent(color))){
                bool[,] mat = x.possibleMovements();
                if (mat[k.position.line, k.position.colum]) {
                    return true;
                }
            }
            return false;
        }

        public bool checkmateTest(Color color) {
            if(!isInCheck(color)) {
                return false;
            }
            foreach (Piece x in piecesInGame(color)) {
                bool[,] mat = x.possibleMovements();
                for(int i=0; i<board.lines; i++) {
                    for(int j=0; j<board.colums; j++) {
                        if (mat[i, j]) {
                            Position aux = new Position(i, j);
                            Position aux2 = new Position(x.position.line, x.position.colum); ;
                            Piece capturedPiece = doMovement(x.position, aux);
                            bool checkTest = isInCheck(color);
                            undoMovement(aux2, aux, capturedPiece);
                            if (!checkTest) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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

            insertNewPiece('c', 7, new Pawn(board, Color.Black));
            insertNewPiece('c', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 6, new Tower(board, Color.Black));
            insertNewPiece('e', 7, new Pawn(board, Color.Black));
            insertNewPiece('e', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 8, new King(board, Color.Black));

        }
    }
}
