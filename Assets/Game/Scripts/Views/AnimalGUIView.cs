using System;
using System.Collections;
using Game.Scripts.Presenters;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Views
{
    public class AnimalGUIView : MonoBehaviour
    {
        #region Fields

        private Transform _animalNameTagText;
        private Transform _animalTransform;
        private bool _isFeedReady = true;
        
        [SerializeField] private GameObject _animalCarePanel;
        [SerializeField] private Vector3 _foodOffset;

        #endregion

        #region UnityAPIs

        private void Start()
        {
            AnimalView.OnMouseDownAnimalView += OnMouseDownedAnimalView;
        }

        private void OnDestroy()
        {
            AnimalView.OnMouseDownAnimalView -= OnMouseDownedAnimalView;
        }

        #endregion


        #region Events

        private void OnMouseDownedAnimalView(string animalName, Transform animalTransform)
        {
            SetAnimalNameAtNameTag(animalName);
            SetAnimalTransform(animalTransform);
            ToggleAnimalCarePanel();
        }


        #endregion

        #region Methods
        private void SetAnimalTransform(Transform animalTransform)
        {
            _animalTransform = animalTransform;
        }

        private void SetAnimalNameAtNameTag(string animalName)
        {
            _animalNameTagText = _animalCarePanel
                .transform
                .Find("NameTag")
                .Find("NameText");
            _animalNameTagText
                .GetComponent<TextMeshProUGUI>()
                .text = animalName;
        }

        private void ToggleAnimalCarePanel()
        {
            var isShow = !_animalCarePanel.activeSelf;
            _animalCarePanel.SetActive(isShow);
        }

        #endregion

        #region UIs

        public void OnClickFeedBtn()
        {
            _animalCarePanel.SetActive(false);
            
            if (!_isFeedReady) return;
            
            var food = _animalTransform.Find("Food");
            
            _isFeedReady = false;
            StartCoroutine(ShowFoodInSeconds(food, 1f));
            
            // Activate Food Factor
            var animalPresenter = _animalTransform.GetComponent<AnimalPresenter>();
            animalPresenter.ActivateFoodFactor();
        }

        public void OnClickPetBtn()
        {
            _animalCarePanel.SetActive(false);
            
            var heart = _animalTransform.Find("Heart");
            StartCoroutine(ShowHeartInSeconds(heart, 1f));
        }

        private IEnumerator ShowHeartInSeconds(Transform heart, float delay)
        {
            heart.gameObject.SetActive(true);
            
            yield return new WaitForSeconds(delay);
            
            heart.gameObject.SetActive(false);
        }

        private IEnumerator ShowFoodInSeconds(Transform food, float delay)
        {
            var originPos = food.localPosition;
            var rb2d = _animalTransform.gameObject.GetComponent<Rigidbody2D>();
            var towardDir = rb2d.velocity.normalized;
            if (towardDir.x > 0f)
            {
                food.localPosition = _foodOffset;
            }
            food.gameObject.SetActive(true);
            
            yield return new WaitForSeconds(delay);
            
            food.gameObject.SetActive(false);
            food.localPosition = originPos;
            _isFeedReady = true;
        }

        #endregion
    }
}