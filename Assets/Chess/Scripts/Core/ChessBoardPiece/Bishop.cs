using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core.ChessBoardPiece
{

    public class Bishop : ChessPiece
    {
        protected override void Awake()
        {
            base.Awake();
            Type = PieceType.Bishop;
        }

        public override List<Vector2Int> CalculatePossibleMoves(ChessPieceMapper board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            int[][] directions = new int[][] { new int[] { 1, 1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { -1, -1 } };

            foreach (int[] direction in directions)
            {
                for (int i = 1; i < 8; i++)
                {
                    int newRow = Row + direction[0] * i;
                    int newCol = Column + direction[1] * i;

                    if (!IsWithinBounds(newRow, newCol)) break;

                    if (board.IsEmpty(newRow, newCol))
                    {
                        moves.Add(new Vector2Int(newRow, newCol));
                    }
                    else
                    {
                        if (board.IsPieceOfOppositeColor(newRow, newCol, this.Color))
                        {
                            moves.Add(new Vector2Int(newRow, newCol));
                        }
                        break;
                    }
                }
            }

            return moves;
        }
    }

}
