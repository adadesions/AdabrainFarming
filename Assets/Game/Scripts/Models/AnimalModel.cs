using System;
using System.Collections;
using Game.Scripts.Core.DataSheets;
using Game.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Models
{
    public class AnimalModel : MonoBehaviour
    {
        #region Fields

        
        private bool _isWalk;
        private int _curAge;
        private float _curGrowth;
        private Animator _anim;
        private bool _isMature;
        private bool _isProductionActivated;
        private bool _isProductReady;
        
        #region SerializeField

        [SerializeField] private string _animalName;
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _walkCooldown = 2f;
        [SerializeField] private AnimalDataSheet _animalDataSheet;
        [SerializeField] private float _foodFactor = 1.0f;

        #endregion

        #endregion

        #region State Events
        public event UnityAction OnProductReadied;
        public event UnityAction<bool> OnIsMatureChanged;
        public event UnityAction<bool> OnIsWalkChanged; 

        #endregion

        #region Properties

        public bool IsWalk
        {
            get => _isWalk;
            set
            {
                _isWalk = value;
                OnIsWalkChanged?.Invoke(_isWalk);
            }
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float LastTimeWalk { get; set; }

        public float WalkCooldown
        {
            get => _walkCooldown;
            set => _walkCooldown = value;
        }

        public string Name
        {
            get => _animalName;
            set => _animalName = value;
        }

        public float GrowthPoint
        {
            get => _curGrowth;
            set
            {
                _curGrowth = value;
                if (_curGrowth >= _animalDataSheet.GrowthPoints[_curAge])
                {
                    _curAge++;
                    _curGrowth = 0;

                    if (_curAge >= 2)
                    {
                        _isMature = true;
                        OnIsMatureChanged?.Invoke(_isMature);

                        // TODO: For Activate Production
                        if (!_isProductionActivated)
                        {
                            ActivateProduction();
                        }
                    }
                }
            }
        }

        private void ActivateProduction()
        {
            _isProductionActivated = true;
        }

        public int Age
        {
            get => _curAge;
            private set => _curAge = value;
        }

        public float FoodFactor
        {
            get => _foodFactor;
            set => _foodFactor = value;
        }

        public bool IsProductReady
        {
            get => _isProductReady;
            set => _isProductReady = value;
        }

        #endregion

        #region UnityAPIs

        private void Start()
        {
            GameManager.OnDayChanged += OnDayChanged;
            _curAge = _animalDataSheet.StartingAge;
        }

        private void OnDestroy()
        {
            GameManager.OnDayChanged -= OnDayChanged;
        }

        #endregion

        #region Event Methods

        private void OnDayChanged()
        {
            _foodFactor = 1;

            if (_isProductionActivated)
            {
                _isProductReady = true;
                OnProductReadied?.Invoke();
            }
        }

        #endregion

        #region Methods

        public void UpdateGrowthPoint()
        {
            GrowthPoint += _animalDataSheet.BaseGrowthRate * _foodFactor;
        }

        #endregion

        public void ActivateFoodFactor()
        {
            _foodFactor = _animalDataSheet.FoodDataSheet.GrowthModifier;
        }
    }
}
