using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Scripts.Core;

namespace Chess.Scripts.Core.ChessBoardPiece
{
    public enum PieceType {None, Pawn, Rook, Knight, Bishop, Queen, King }
    public enum PieceColor {None, White, Black }

    public abstract class ChessPiece : MonoBehaviour
    {
        protected ChessPlayerPlacementHandler _placementHandler;
        [HideInInspector]
        public PieceType Type;
        public PieceColor Color;

        public int Row
        {
            get { return _placementHandler.row; }
            set { _placementHandler.row = value; }
        }
        public int Column
        {
            get { return _placementHandler.column; }
            set { _placementHandler.column = value; }
        }

        protected virtual void Awake()
        {
            _placementHandler = GetComponent<ChessPlayerPlacementHandler>();
            if (_placementHandler == null)
            {
                _placementHandler = gameObject.AddComponent<ChessPlayerPlacementHandler>();
            }
        }

        public abstract List<Vector2Int> CalculatePossibleMoves(ChessPieceMapper board);

        protected bool IsWithinBounds(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }

        protected void AddMoveIfValid(ChessPieceMapper board, int row, int col, List<Vector2Int> moves)
        {
            if (IsWithinBounds(row, col) && (board.IsEmpty(row, col) || board.IsPieceOfOppositeColor(row, col, this.Color)))
            {
                moves.Add(new Vector2Int(row, col));
            }
        }
    }
}
