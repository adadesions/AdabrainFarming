using System;
using System.Collections;
using Game.Scripts.Core.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Views
{
    [RequireComponent(typeof(Animator))]
    public class AnimalView : MonoBehaviour
    {
        #region Fields

        private Animator _anim;
        private string _animalNameUI;
        
        [SerializeField] private GameObject _productBubble;
        private bool _isProductBubbleShowing;
        private Transform _gainProductUI;
            
        #endregion

        #region UI Events

        // External UI Events
        public static event UnityAction<string, Transform> OnMouseDownAnimalView;
        
        // Internal UI Events
        public event UnityAction OnMouseDownedAnimalView;
        public event UnityAction OnClickedProductBubble;

        #endregion

        #region Properties

        public string AnimalNameUI
        {
            get => _animalNameUI;
            set => _animalNameUI = value;
        }

        #endregion

        #region Unity APIs

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _gainProductUI = transform.Find("GainProductUI");
        }

        #endregion

        #region Methods

        public void ChangeAnimationDirection(float directionX)
        {
            _anim.SetFloat("DirectionX", directionX);
        }

        public void SetIsWalk(bool isWalk)
        {
            _anim.SetBool("IsWalk", isWalk);
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

        public void ShowGainProduct(string productName, int productAmount)
        {
            var tmpComp = _gainProductUI.GetComponentInChildren<TextMeshPro>();
            tmpComp.text = $"+{productAmount} {productName}";
            
            _gainProductUI.gameObject.SetActive(true);
            StartCoroutine(DisappearGainProductUI());
        }

        private IEnumerator DisappearGainProductUI()
        {
            yield return new WaitForSeconds(1f);
            _gainProductUI.gameObject.SetActive(false);
        }

        #endregion

        #region UI Event Methods

        private void OnMouseDown()
        {
            var isProductBubbleShowing = _isProductBubbleShowing;
            
            OnMouseDownedAnimalView?.Invoke();
            
            if (isProductBubbleShowing)
            {
                OnClickedProductBubble?.Invoke();
            }
            else
            {
                // Show AnimalCarePanel
                OnMouseDownAnimalView?.Invoke(_animalNameUI, transform);
            }
            
        }

        #endregion
    }
}