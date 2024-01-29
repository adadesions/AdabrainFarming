using Game.Scripts.Core.Interactive;
using UnityEngine;

namespace Game.Scripts.Views
{
    public class CursorView : MonoBehaviour
    {
        private Camera _camera;
        private Texture2D _defaultCursorTexture;

        private void Start()
        {
            CursorInteractive.OnCursorInteractExited += OnCursorInteractExited;
        }

        private void OnDestroy()
        {
            CursorInteractive.OnCursorInteractExited += OnCursorInteractExited;
        }

        private void OnCursorInteractExited()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}