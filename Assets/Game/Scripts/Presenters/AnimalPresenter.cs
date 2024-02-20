using System;
using Game.Scripts.Core.Managers;
using Game.Scripts.Models;
using Game.Scripts.Views;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

namespace Game.Scripts.Presenters
{
    [RequireComponent(typeof(AnimalView))]
    [RequireComponent(typeof(AnimalModel))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class AnimalPresenter : MonoBehaviour
    {
        #region Fields

        private AnimalModel _animalModel;
        private AnimalView _animalView;
        private Rigidbody2D _rb2d;
        private Vector2 _targetPos;
        private TextMeshPro _nameFloatingUI;
        private float _lastTimeClickedProduct;

        #endregion

        #region UnityAPIs

        private void OnEnable()
        {
            GameManager.OnDayChanged += OnDayChanged;

        }

        private void OnDisable()
        {
            GameManager.OnDayChanged -= OnDayChanged;
        }

        private void Start()
        {
            _animalModel = GetComponent<AnimalModel>();
            _animalView = GetComponent<AnimalView>();
            _rb2d = GetComponent<Rigidbody2D>();
            _nameFloatingUI = GetComponentInChildren<TextMeshPro>();

            _nameFloatingUI.text = _animalModel.Name;

            #region State Events
            _animalModel.OnIsWalkChanged += OnIsWalkChanged;
            _animalModel.OnIsMatureChanged += OnIsMatureChanged;
            _animalModel.OnProductReadied += OnProductReadied;
            _animalModel.OnGivenProduct += OnGivenProduct;

            #endregion

            #region UI Events
            
            _animalView.OnMouseDownedAnimalView += OnMouseDownedAnimalView;
            _animalView.OnClickedProductBubble += OnClickedProductBubble;

            #endregion

        }

        private void OnDestroy()
        {
            #region State Events
            
            _animalModel.OnIsWalkChanged -= OnIsWalkChanged;
            _animalModel.OnIsMatureChanged -= OnIsMatureChanged;
            _animalModel.OnProductReadied -= OnProductReadied;
            _animalModel.OnGivenProduct -= OnGivenProduct;
            
            #endregion

            #region UI Events
            
            _animalView.OnMouseDownedAnimalView -= OnMouseDownedAnimalView;
            _animalView.OnClickedProductBubble -= OnClickedProductBubble;

            #endregion
        }


        private void FixedUpdate()
        {
            if (Time.time > _animalModel.LastTimeWalk + _animalModel.WalkCooldown)
            {
                _animalModel.LastTimeWalk = Time.time;
                var oddWalk = Random.Range(0f, 1f);
                if (oddWalk >= 0.3f)
                {
                    AnimalWalk();
                }
                else
                {
                    AnimalStop();
                }
            }
        }

        #endregion

        #region Methods

        private void AnimalStop()
        {
            _rb2d.velocity = Vector2.zero;
            _animalModel.IsWalk = false;
        }

        private void AnimalWalk()
        {
            var directionX = Random.Range(-1.0f, 1.1f);
            _rb2d.velocity = new Vector2(directionX * _animalModel.Speed, _rb2d.velocity.y);
            _animalModel.IsWalk = true;
            _animalView.ChangeAnimationDirection(directionX);
        }

        #endregion


        #region Events

        private void OnGivenProduct(string productName, int productAmount)
        {
            if (Time.time > _lastTimeClickedProduct + 3.0f)
            {
                _lastTimeClickedProduct = Time.time;
                _animalView.ShowGainProduct(productName, productAmount);
            }
        }

        private void OnClickedProductBubble()
        {
            _animalModel.ResetProductState();
        }

        private void OnProductReadied()
        {
            _animalView.ShowProductBubble(true);
        }

        private void OnIsMatureChanged(bool isMature)
        {
            _animalView.UpdateToMatureState(isMature);
        }

        private void OnDayChanged()
        {
            _animalModel.UpdateGrowthPoint();
            print($"Current Age: {_animalModel.Age}");
            print($"Current GP: {_animalModel.GrowthPoint}");
        }

        private void OnIsWalkChanged(bool isWalk)
        {
            _animalView.SetIsWalk(isWalk);
        }

        private void OnMouseDownedAnimalView()
        {
            _animalView.AnimalNameUI = _animalModel.Name;
            _animalModel.IsProductReady = false;
            _animalView.ShowProductBubble(false);
        }

        #endregion
        

        public void ActivateFoodFactor()
        {
            _animalModel.ActivateFoodFactor();
        }
    }
}