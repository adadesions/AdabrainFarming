using System;
using UnityEngine;

namespace Game.Scripts.Views
{
    [RequireComponent(typeof(Animator))]
    public class AnimalView : MonoBehaviour
    {
        private Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void ChangeAnimationDirection(float directionX)
        {
            _anim.SetFloat("DirectionX", directionX);
        }

        public void SetIsWalk(bool isWalk)
        {
            _anim.SetBool("IsWalk", isWalk);
        }
    }
}