using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Core.Interactive
{
    public class CursorInteractive : MonoBehaviour
    {
        [SerializeField] private Texture2D _onMouseEnterCursor;
        
        // UI States
        public static event UnityAction OnCursorInteractExited;

        public Texture2D OnMouseEnterCursor
        {
            get => _onMouseEnterCursor;
            set => _onMouseEnterCursor = value;
        }

        private void OnMouseEnter()
        {
            Cursor.SetCursor(_onMouseEnterCursor, Vector2.zero, CursorMode.ForceSoftware);
        }

        private void OnMouseExit()
        {
            OnCursorInteractExited?.Invoke();
        }
    }
}