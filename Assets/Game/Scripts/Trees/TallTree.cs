using System;
using UnityEngine;

namespace Game.Scripts.Trees
{
    public class TallTree : MonoBehaviour
    {
        [SerializeField] private int _hp = 5;
        private Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }


        public void Cut()
        {
            _hp -= 1;
            HandleTree();
        }

        private void HandleTree()
        {
            if (_hp < Mathf.Round(_hp * 0.5f))
            {
                _anim.SetTrigger("NextState");
            }
        }
    }
}
