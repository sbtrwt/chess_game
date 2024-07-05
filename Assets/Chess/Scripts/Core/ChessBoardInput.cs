using UnityEngine;
namespace Chess.Scripts.Core
{
    public class ChessBoardInput : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) // Left mouse button
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = -_mainCamera.transform.position.z;
                Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

                if (hit.collider != null)
                {
                    ChessPlayerPlacementHandler placementHandler = hit.collider.GetComponent<ChessPlayerPlacementHandler>();
                    if (placementHandler != null)
                    {
                        GameManager.Instance.HandleTileClick(placementHandler.row, placementHandler.column);
                    }
                }
            }
        }
    }
}