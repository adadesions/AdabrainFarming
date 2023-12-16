using System;
using Game.Scripts.Core.Managers;
using Game.Scripts.InventorySystem;
using Game.Scripts.Items;
using UnityEngine;

namespace Game.Scripts.Core.Interactive
{
    public class PlayerInteractItem : MonoBehaviour
    {
        private PlayerDataManager _playerDataManager;
        private Inventory _inventory;

        private void Start()
        {
            _inventory = InventoryManager.Instance.InventoryStore;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<CollectableItem>(out var collectableItemComp))
            {
                collectableItemComp.Collect(_inventory);
            }
        }
    }
}
