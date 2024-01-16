using System;
using Game.Scripts.Items;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Scripts.CropSystem
{
    public class CropTile : MonoBehaviour
    {
        private GameObject _highlight;
        private bool _isEntered;
        
        [SerializeField] private GameObject _cropItemPrefab;
        private bool _isPlanted;
        private SpriteRenderer _sr;
        private Sprite _dirtSprite;

        // Start is called before the first frame update
        void Start()
        {
            _highlight = transform.Find("Highlight").gameObject;
            _sr = GetComponent<SpriteRenderer>();
            _dirtSprite = _sr.sprite;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isEntered && Input.GetMouseButtonDown(0))
            {
                if (!_isPlanted)
                {
                    PlantCropItem();
                }
            }
        }

        private void PlantCropItem()
        {
            // Instantiate Crop Item 
            var cropItemClone = Instantiate(_cropItemPrefab, transform);
            cropItemClone.transform.localPosition = Vector3.zero;
            
            // Observing OnHarvest Event
            var cropController = cropItemClone.GetComponent<ItemCropController>();
            cropController.OnHarvest += OnHarvest;
            
            // Planting Status
            _isPlanted = true;
            
            // Change Sprite Crop Tile
            ChangeSpriteCropTile();
        }

        private void OnHarvest()
        {
            _isPlanted = false;
            ChangeSpriteCropTile();
        }

        private void ChangeSpriteCropTile()
        {
            _sr.sprite = _isPlanted ? null : _dirtSprite;
        }

        private void OnMouseEnter()
        {
            _isEntered = true;
            _highlight.SetActive(true);
        }

        private void OnMouseExit()
        {
            _isEntered = false;
            _highlight.SetActive(false);
        }
    }
}
