using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Game.Prepare
{
    [Serializable]
    public class PPlayerData
    {
        public Vector3 position;
        public List<int> historicalData;

        public PPlayerData(Vector3 position, List<int> historicalData)
        {
            this.position = position;
            this.historicalData = historicalData;
        }
    }

    public class PPlayerDataSet
    {
        public List<PPlayerData> players;

        public PPlayerDataSet(List<PPlayerData> players)
        {
            this.players = players;
        }
    }
    
    public class PSaveManager : MonoBehaviour
    {
        private PPlayerDataSet _saveData;
        private static string _dirPath = "Assets/SavedData";
        private string _filePath = _dirPath + "/PplayerPosition.json";

        // Start is called before the first frame update
        void Start()
        {
            var temp = new Dictionary<string, string>
            {
                { "name", "Ada De Sions" },
                { "level", "99"}
            };
            _saveData = new PPlayerDataSet(new List<PPlayerData>()
            {
                new PPlayerData(
                    new Vector3(1, 1, 1),
                    new List<int> { 1, 2, 3 }
                ),
                new PPlayerData(
                    new Vector3(2, 2, 2),
                    new List<int> { 1, 2, 3 }
                ),
            });
            
            print(_filePath);
        }
        

        private void OnApplicationQuit()
        {
            Save();
        }

        private void Save()
        {
            var jsonData = JsonUtility.ToJson(_saveData);
            print(jsonData);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
