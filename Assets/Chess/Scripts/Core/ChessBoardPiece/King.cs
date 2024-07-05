using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core.ChessBoardPiece
{
    public class King : ChessPiece
    {
        protected override void Awake()
        {
            base.Awake();
            Type = PieceType.King;
        }

        public override List<Vector2Int> CalculatePossibleMoves(ChessPieceMapper board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            int[][] directions = new int[][]
            {
            new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 },
            new int[] { 1, 1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { -1, -1 }
            };

            foreach (int[] direction in directions)
            {
                int newRow = Row + direction[0];
                int newCol = Column + direction[1];

                AddMoveIfValid(board, newRow, newCol, moves);
            }

            return moves;
        }
    }
}
