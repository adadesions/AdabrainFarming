using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.Managers;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Game.Scripts.Items
{
    public class ItemCropController : MonoBehaviour
    {
        [SerializeField] private ItemCropData _cropData;
        private SpriteRenderer _sr;
        private int _plantDays;
        private int _cropProgress;
        private GameManager _gameManager;

        public UnityAction OnHarvest;
        private bool _isReadyToHarvest;
        private Camera _camera;
        [SerializeField] private int _watering;
        private int _realProgress;
        private Animator _playerAnimator;
        private ItemCropModel _itemCropModel;
        private ItemCropView _itemCropView;

        private void Awake()
        {
            _itemCropModel = GetComponent<ItemCropModel>();
            _itemCropView = GetComponent<ItemCropView>();
        }

        private void OnEnable()
        {
            _gameManager = GameManager.Instance;
            _gameManager.OnDayChanged += ChangeCropSprite;
            
            // State Events
            _itemCropModel.OnWateringChanged += OnWateringChanged;
            _itemCropModel.OnStoppedGrowing += OnStoppedGrowing;
        }

        private void OnDisable()
        {
            _gameManager.OnDayChanged -= ChangeCropSprite;
            
            // State Events
            _itemCropModel.OnWateringChanged -= OnWateringChanged;
            _itemCropModel.OnStoppedGrowing -= OnStoppedGrowing;
        }


        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _sr = GetComponent<SpriteRenderer>();
            _sr.sprite = _cropData.ProgressSprites[_cropProgress];
            _plantDays = _gameManager.CurrentDay;
            _playerAnimator = _gameManager.GetPlayerAnimator();
            

            // StartCoroutine(GrowingUp());
        }

        private void OnWateringChanged(int wateringValue)
        {
            var isShow = wateringValue < 1;
            _itemCropView.ShowWateringIcon(isShow);
        }
        
        private void OnStoppedGrowing()
        {
            _itemCropView.ShowStopGrowingIcon(true);
        }

        private void ChangeCropSprite()
        {
            _cropProgress = CropProgress();
            SelfDestroy();
            
            // Final Sprite
            if (_realProgress >= _cropData.DaysGrowth - 1)
            {
                _sr.sprite = _cropData.ReadyToHarvestSprites;
                _isReadyToHarvest = true;
                return;
            }
            
            // Progress Sprites
            _itemCropModel.IsGrowing = _cropProgress <= _cropData.DaysGrowth;
            if (_itemCropModel.IsGrowing && _itemCropModel.Watering >= 1)
            {
                _realProgress++;
                _plantDays = _gameManager.CurrentDay;
                _sr.sprite = _cropData.ProgressSprites[_realProgress];
                _itemCropModel.Watering = 0;
                return;
            }
        }

        private void SelfDestroy()
        {
            if (_cropProgress >= _cropData.LifeTime)
            {
                OnHarvest?.Invoke();
                Destroy(gameObject);
            }
        }

        private int CropProgress()
        {
            return _gameManager.CurrentDay - _plantDays;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;
                var ray = _camera.ScreenPointToRay(mousePos);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);
    
                if (hit.collider && hit.collider.gameObject.Equals(gameObject))
                {
                    if (_isReadyToHarvest)
                    {
                        Harvest();
                    }
                    else
                    {
                        Watering();
                    }
                }
            }
        }

        private void Watering()
        {
            _itemCropModel.Watering++;
            
            // Play Player Watering Animation
            // _playerAnimator.SetTrigger("WaterTrigger");
            var mousePos = (Vector2) _camera.ScreenToWorldPoint(Input.mousePosition); 
            var playerPos = _gameManager.GetPlayerPosition();
            var direction = (mousePos - playerPos).normalized;
            
            if (direction.x > 0)
            {
                _playerAnimator.Play("Cat@Watering_Right");    
            }
            else
            {
                _playerAnimator.Play("Cat@Watering_Left");
            }
            
        }

        private void Harvest()
        {
            OnHarvest?.Invoke();
            
            // Instantiate a product
            var product = Instantiate(_cropData.ProductPrefab, transform.position, Quaternion.identity);
            var productLifeTime = product.GetComponent<CollectableItem>().Description.liftTime;
            product.transform.SetParent(_gameManager.ItemPool.transform);
            
            Destroy(product, productLifeTime);
            Destroy(gameObject);
        }
        
    }
}
