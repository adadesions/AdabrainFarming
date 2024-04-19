using Game.Scripts.NPC;
using UnityEngine;

namespace Game.Scripts.Core.Interactive
{
    public class PlayerInteractNpc : MonoBehaviour
    {
        private Vector3 _mousePos;
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                HandleMouseClickOnNpc();
            }
        }

        private void HandleMouseClickOnNpc()
        {
            var hit = Physics2D.Raycast(_mousePos, Vector2.zero);
            if (hit.collider)
            {
                var target = hit.collider.gameObject;
                if (target.TryGetComponent<NpcView>(out var npcView))
                {
                    npcView.Talk();
                }
            }
        }
    }
}