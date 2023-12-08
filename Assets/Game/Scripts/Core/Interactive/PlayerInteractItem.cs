using System;
using Game.Scripts.Core.Managers;
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
            _inventory = GetComponent<Inventory>();
        }

        // private void Start()
        // {
        //     _playerDataManager = GetComponent<PlayerDataManager>();
        //
        //     var playerDataToSave = new PlayerData
        //     {
        //         Id = 1,
        //         Name = "Ada"
        //     };
        //     
        //     _playerDataManager.SavePlayerData(playerDataToSave);
        // }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<CollectableItem>(out var collectableItemComp))
            {
                // PlayerData loaded = _playerDataManager.LoadPlayerData();
                // print(loaded.Name);
                _inventory.ItemList.Add(other.name);
                Destroy(collectableItemComp.gameObject);
            }
        }
    }
}
