using System.Collections.Generic;
using Game.Scripts.Items;
using UnityEngine;

namespace Game.Scripts.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        // Old Data Structure for store item in inventory
        private List<string> _itemList = new();
        private Dictionary<string, InventoryItem> _inventoryItems = new();
        private InventoryManager _inventoryManager;

        public List<string> ItemList
        {
            get => _itemList;
            set => _itemList = value;
        }

        public Dictionary<string, InventoryItem> InventoryItems
        {
            get => _inventoryItems;
            set => _inventoryItems = value;
        }

        private void Start()
        {
            _itemList = new List<string>();
            _inventoryManager = InventoryManager.Instance;
        }

        public void Add(CollectableItem collectableItem)
        {
            var itemName = collectableItem.Description.itemName;
            if (InventoryItems.TryGetValue(itemName, out var item))
            {
                item.Quantity++;
            }
            else
            {
                var invItem = new InventoryItem(collectableItem, 1);   
                InventoryItems.Add(itemName, invItem);
            }

            _inventoryManager.UpdateInventoryGUI();
            PrintInventory();
        }

        private void PrintInventory()
        {
            foreach (var kvp in InventoryItems)
            {
                print($"Item name: {kvp.Key}, Quantity: {kvp.Value.Quantity}");   
            }
        }
    }
}
