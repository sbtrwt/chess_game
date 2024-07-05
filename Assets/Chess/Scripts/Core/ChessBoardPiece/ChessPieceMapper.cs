using Chess.Scripts.Core.ChessBoardPiece;

namespace Chess.Scripts.Core.ChessBoardPiece
{
    public class ChessPieceMapper
    {
        private ChessPiece[,] _pieceOnBoard = new ChessPiece[8, 8];

        public void SetPiece(int row, int col, ChessPiece piece)
        {
            _pieceOnBoard[row, col] = piece;
            if (piece != null)
            {
                piece.Row = row;
                piece.Column = col;
            }
        }

        public ChessPiece GetPiece(int row, int col)
        {
            return _pieceOnBoard[row, col];
        }

        public bool IsEmpty(int row, int col)
        {
            return _pieceOnBoard[row, col] == null;
        }

        public bool IsPieceOfOppositeColor(int row, int col, PieceColor color)
        {
            return !IsEmpty(row, col) && _pieceOnBoard[row, col].Color != color;
        }
    }

}
