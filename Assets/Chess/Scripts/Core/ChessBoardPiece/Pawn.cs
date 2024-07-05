using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core.ChessBoardPiece
{
    public class Pawn : ChessPiece
    {
        protected override void Awake()
        {
            base.Awake();
            Type = PieceType.Pawn;
        }

        public override List<Vector2Int> CalculatePossibleMoves(ChessPieceMapper board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            int direction = (Color == PieceColor.White) ? 1 : -1;

            // Move forward
            if (IsWithinBounds(Row + direction, Column) && board.IsEmpty(Row + direction, Column))
            {
                moves.Add(new Vector2Int(Row + direction, Column));

                // First move can be two squares
                if ((Color == PieceColor.White && Row == 1) || (Color == PieceColor.Black && Row == 6))
                {
                    if (board.IsEmpty(Row + 2 * direction, Column))
                    {
                        moves.Add(new Vector2Int(Row + 2 * direction, Column));
                    }
                }
            }

            // Capture diagonally
            int[] captureColumns = { Column - 1, Column + 1 };
            foreach (int col in captureColumns)
            {
                if (IsWithinBounds(Row + direction, col) && board.IsPieceOfOppositeColor(Row + direction, col, Color))
                {
                    moves.Add(new Vector2Int(Row + direction, col));
                }
            }

            return moves;
        }
    }
}
