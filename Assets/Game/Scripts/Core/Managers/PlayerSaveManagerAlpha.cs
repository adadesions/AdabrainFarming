using System;
using System.Collections.Generic;
using System.IO;
using Game.Scripts.InventorySystem;
using Game.Scripts.Items;
using UnityEngine;

namespace Game.Scripts.Core.Managers
{
    [Serializable]
    public class PlayerSaveManagerAlpha : MonoBehaviour
    {
        private static string _dirPath = "Assets/SavedData";
        [SerializeField]
        private string _filePath = _dirPath + "/playerPosition.json";
        private GameObject _player;
        private PlayerDataJson _playerData;
        private Inventory _inventory;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _playerData = new PlayerDataJson();
            _inventory = _player.GetComponent<Inventory>();
            
            // Load Data from file
            _player.transform.position = LoadPlayerPosition();
            _inventory.ItemList = LoadInventoryItemList();

        }

        private List<string> LoadInventoryItemList()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var data = JsonUtility.FromJson<PlayerDataJson>(json);
                return data.itemInventory;
            }

            return new List<string>();
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

        public void SaveItemInInventory(List<string> itemList)
        {
            foreach (var itemId in itemList)
            { 
                _playerData.itemInventory.Add(itemId);
            }
        }

        public void Save()
        {
            SavePlayerPosition(_player.transform.position);
            SaveItemInInventory(_player.GetComponent<Inventory>().ItemList);
            
            var json = JsonUtility.ToJson(_playerData);
            File.WriteAllText(_filePath, json);
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}
