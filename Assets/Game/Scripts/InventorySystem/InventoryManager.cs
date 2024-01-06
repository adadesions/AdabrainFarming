using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        private static InventoryManager _instance;
        
        [SerializeField] private List<GameObject> _inventoryItemUis;
        private Inventory _inventory;

        public static InventoryManager Instance
        {
            get => _instance;
            private set => _instance = value;
        }

        public Inventory InventoryStore
        {
            get => _inventory;
            set => _inventory = value;
        }

        private void Awake()
        {
            if (_instance != this && _instance != null)
            {
                Destroy(this);  
                return;
            }

            _instance = this;
            _inventory = GetComponent<Inventory>();
        }

        // Start is called before the first frame update
        void Start()
        {
            UpdateInventoryGUI();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void UpdateInventoryGUI()
        {
            var count = 0;
            foreach (var kvp in _inventory.InventoryItems)
            {
                var itemDescription = kvp.Value.ItemObject.Description;
                var quantity = kvp.Value.Quantity.ToString();
                var invGUI = _inventoryItemUis[count];
                
                invGUI.SetActive(true);
                var textGUI = invGUI.transform.Find("Text").Find("Text (TMP)");
                textGUI.GetComponent<TextMeshProUGUI>().text = $"x{quantity}";

                var imageObj = invGUI.transform.Find("Image");
                imageObj.GetComponent<Image>().sprite = itemDescription.sprite;
                count++;
            }
        }
    }
}
