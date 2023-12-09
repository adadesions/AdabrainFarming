using System;
using Game.Scripts.Trees;
using UnityEngine;

namespace Game.Scripts.Core.Interactive
{
    public class PlayerInteractiveMouse : MonoBehaviour
    {
        private Vector3 _mousePos;
        private Camera _mainCamera;
        private GameObject _target;
        private Animator _anim;
        [SerializeField] private float _cuttingRange = 1.5f;
        private float _lastTimeCut;
        [SerializeField] private float _cooldownCutting = 0.2f;

        private void Start()
        {
            _mainCamera = Camera.main;
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > _lastTimeCut + _cooldownCutting)
            {
                _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                HandleMouseClick();
            }
        }

        private void HandleMouseClick()
        {
            var hit = Physics2D.Raycast(_mousePos, Vector2.zero);
            if (hit.collider)
            {
                _target = hit.collider.gameObject;
                var isTree = _target.name.ToLower().Contains("tree");
                var isTreeRange = Vector2.Distance(
                    _target.transform.position, 
                    transform.position) < _cuttingRange;


                if (!_target.TryGetComponent<TreeComponent>(out var treeComp)) 
                    return;
                
                var isCuttable = treeComp.Hp > 0;
                var isReady = Time.time > _lastTimeCut + _cooldownCutting;
                var canCut = isTree && isTreeRange && isCuttable && isReady;

                if (canCut)
                {
                    _lastTimeCut = Time.time;
                    _anim.SetTrigger("CutTrigger");
                }
            }
        }
        
        // Animation Event Functions
        public void SetFinishCutting()
        {
            if (_target.TryGetComponent<TreeComponent>(out var treeComp))
            {
                treeComp.Cut();
            }
            _anim.SetBool("IsCutting", false);
        }
    }
}
