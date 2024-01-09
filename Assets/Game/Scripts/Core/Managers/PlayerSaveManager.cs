using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Game.Scripts.Core.DataStructures;
using Game.Scripts.InventorySystem;
using Game.Scripts.Items;
using UnityEngine;

namespace Game.Scripts.Core.Managers
{
    [Serializable]
    public class PlayerDataJson
    {
        public Vector3 lastPosition;
        public SerializableDictionary<string, InventoryItem> itemInventory;
    }
    
    public class PlayerSaveManager : MonoBehaviour
    {
        private static string _dirPath = "Assets/SavedData";
        private string _filePath = _dirPath + "/playerPosition.json";
        private GameObject _player;
        private PlayerDataJson _playerData;
        private Inventory _inventory;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _playerData = new PlayerDataJson();
            _inventory = InventoryManager.Instance.InventoryStore;
            
            // Load Data from file
            _player.transform.position = LoadPlayerPosition();
            _inventory.InventoryItems = LoadInventoryItemList();

        }

        private Dictionary<string, InventoryItem>  LoadInventoryItemList()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var data = JsonUtility.FromJson<PlayerDataJson>(json);
                print(data.lastPosition);
                return data.itemInventory.ToDictionary();
            }

            Save();
            return new Dictionary<string, InventoryItem>();
        }

        public void SavePlayerPosition(Vector3 playerPosition)
        {
            // Old Version
            // var data = new PlayerDataJson
            // {
            //     lastPosition = playerPosition
            // };

            // New Version
            _playerData.lastPosition = playerPosition;
        }

        public Vector3 LoadPlayerPosition()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var data = JsonUtility.FromJson<PlayerDataJson>(json);
                return data.lastPosition;
            }

            return Vector3.zero;
        }

        private void SaveItemInInventory(Dictionary<string, InventoryItem> inventoryItems)
        {
            var serializableDict = new SerializableDictionary<string, InventoryItem>(inventoryItems);
            _playerData.itemInventory = serializableDict;
        }
        

        public void Save()
        {
            SavePlayerPosition(_player.transform.position);
            
            // Real Usage
            SaveItemInInventory(_inventory.InventoryItems);
            
            var json = JsonUtility.ToJson(_playerData);
            File.WriteAllText(_filePath, json);
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}
