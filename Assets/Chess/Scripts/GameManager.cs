using UnityEngine;
using System.Collections.Generic;
using Chess.Scripts.Core.ChessBoardPiece;
using Chess.Scripts.Core;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
  
    [SerializeField] private GameObject _highlightPrefab;

  
    private ChessPieceMapper _boardMapper;
    private ChessPiece _selectedPiece;
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeBoard();
        }
        else
        {
            Destroy(gameObject);
        }
    }

  

    private void InitializeBoard()
    {
        _boardMapper = new ChessPieceMapper();
    }

    public void MapPiece(GameObject pieceObject)
    {
        ChessPiece piece = pieceObject.GetComponent<ChessPiece>();
        ChessPlayerPlacementHandler placementHandler = pieceObject.GetComponent<ChessPlayerPlacementHandler>();
        if (piece != null && placementHandler != null)
        {
            _boardMapper.SetPiece(placementHandler.row, placementHandler.column, piece);
        }
    }

    public void HandleTileClick(int row, int col)
    {
        if (_selectedPiece == null)
        {
            SelectPiece(row, col);
        }
        else
        {
            // Check if the clicked tile is a valid move
            List<Vector2Int> validMoves = _selectedPiece.CalculatePossibleMoves(_boardMapper);
            if (validMoves.Contains(new Vector2Int(row, col)))
            {
                MovePiece(_selectedPiece, row, col);
                ClearHighlights();
                _selectedPiece = null;
            }
            else
            {
                // If not a valid move, treat it as a new selection
                SelectPiece(row, col);
            }
        }
    }

    private void SelectPiece(int row, int col)
    {
        ClearHighlights();

        ChessPiece piece = _boardMapper.GetPiece(row, col);
        if (piece != null)
        {
            _selectedPiece = piece;
            HighlightPossibleMoves(piece);
        }
        else
        {
            _selectedPiece = null;
        }
    }

    private void HighlightPossibleMoves(ChessPiece piece)
    {
        List<Vector2Int> moves = piece.CalculatePossibleMoves(_boardMapper);

        foreach (Vector2Int move in moves)
        {          
            GameObject highlightObj = ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
            if (highlightObj != null && !_boardMapper.IsEmpty(move.x, move.y) && _boardMapper.IsPieceOfOppositeColor(move.x, move.y, piece.Color))
            {
                // Highlight enemy pieces in red
                highlightObj.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void ClearHighlights()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
    }

    private void MovePiece(ChessPiece piece, int newRow, int newCol)
    {
        _boardMapper.SetPiece(piece.Row, piece.Column, null);
        _boardMapper.SetPiece(newRow, newCol, piece);
        piece.Row = newRow;
        piece.Column = newCol;
        ChessPlayerPlacementHandler placementHandler = piece.GetComponent<ChessPlayerPlacementHandler>();
        placementHandler.row = newRow;
        placementHandler.column = newCol;
        piece.transform.position = ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol).transform.position;
    }
}