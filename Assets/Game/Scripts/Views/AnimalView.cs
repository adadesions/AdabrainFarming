using System;
using UnityEngine;

namespace Game.Scripts.Views
{
    [RequireComponent(typeof(Animator))]
    public class AnimalView : MonoBehaviour
    {
        private Animator _anim;
        [SerializeField] private GameObject _animalCarePanel;

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

        private void OnMouseDown()
        {
            var isShowing = _animalCarePanel.activeSelf;
            ShowAnimalCarePanel(!isShowing);
        }

        private void ShowAnimalCarePanel(bool isShow)
        {
            _animalCarePanel.SetActive(isShow);
        }
    }
}