using System;
using UnityEngine;

namespace Chess.Scripts.Core.ChessBoardPiece
{
    public class ChessPieceMapHandler : MonoBehaviour {
       
        private void Start() {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.MapPiece(gameObject);
            }
        }
    }
}