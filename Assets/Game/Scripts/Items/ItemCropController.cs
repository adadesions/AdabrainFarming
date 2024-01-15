using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.Managers;
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

        private void OnEnable()
        {
            _gameManager = GameManager.Instance;
            _gameManager.OnDayChanged += ChangeCropSprite;
        }

        private void OnDisable()
        {
            _gameManager.OnDayChanged -= ChangeCropSprite;
        }

        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _sr = GetComponent<SpriteRenderer>();
            _sr.sprite = _cropData.ProgressSprites[_cropProgress];
            _plantDays = _gameManager.CurrentDay;
            // StartCoroutine(GrowingUp());
        }

        // private IEnumerator GrowingUp()
        // {
        //     while (_cropProgress < _cropData.ProgressSprites.Count - 1)
        //     {
        //         yield return new WaitForSeconds(5);
        //         _cropProgress++;
        //         _sr.sprite = _cropData.ProgressSprites[_cropProgress];
        //     }
        //     yield return new WaitForSeconds(5);
        //     print("Ready to Harvest");
        //     _sr.sprite = _cropData.ReadyToHarvestSprites;
        // }

        // Update is called once per frame
        // void Update()
        // {
        //     ChangeCropSprite();
        // }

        private void ChangeCropSprite()
        {
            _cropProgress = CropProgress();
            if (_cropProgress < _cropData.DaysGrowth)
            {
                _sr.sprite = _cropData.ProgressSprites[_cropProgress];
            }
            else
            {
                _sr.sprite = _cropData.ReadyToHarvestSprites;
                _isReadyToHarvest = true;
            }
            
            SelfDestroy();
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
                }
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
