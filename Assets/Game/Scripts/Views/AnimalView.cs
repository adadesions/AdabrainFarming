using System;
using Game.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Views
{
    [RequireComponent(typeof(Animator))]
    public class AnimalView : MonoBehaviour
    {
        private Animator _anim;
        private string _animalNameUI;
        
        [SerializeField] private GameObject _productBubble;
        private bool _isProductBubbleShowing;

        // External UI Events
        public static event UnityAction<string, Transform> OnMouseDownAnimalView;
        
        // Internal UI Events
        public event UnityAction OnMouseDownedAnimalView;

        public string AnimalNameUI
        {
            get => _animalNameUI;
            set => _animalNameUI = value;
        }

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
            OnMouseDownedAnimalView?.Invoke();

            if (!_isProductBubbleShowing)
            {
                OnMouseDownAnimalView?.Invoke(_animalNameUI, transform);
            }
        }

        public void UpdateToMatureState(bool isMature)
        {
            _anim.SetBool("IsMature", isMature);
        }

        public void ShowProductBubble(bool isShow)
        {
            _isProductBubbleShowing = isShow;
            _productBubble.SetActive(isShow);
        }
    }
}