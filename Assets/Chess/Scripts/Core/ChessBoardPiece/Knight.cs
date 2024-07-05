using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core.ChessBoardPiece
{
    
        public class Knight : ChessPiece
        {
            protected override void Awake()
            {
                base.Awake();
                Type = PieceType.Knight;
            }

            public override List<Vector2Int> CalculatePossibleMoves(ChessPieceMapper board)
            {
                List<Vector2Int> moves = new List<Vector2Int>();
                int[][] knightMoves = new int[][]
                {
            new int[] { 2, 1 }, new int[] { 1, 2 }, new int[] { -1, 2 }, new int[] { -2, 1 },
            new int[] { -2, -1 }, new int[] { -1, -2 }, new int[] { 1, -2 }, new int[] { 2, -1 }
                };

                foreach (int[] move in knightMoves)
                {
                    int newRow = Row + move[0];
                    int newCol = Column + move[1];

                    AddMoveIfValid(board, newRow, newCol, moves);
                }

                return moves;
            }
        }
    
}
