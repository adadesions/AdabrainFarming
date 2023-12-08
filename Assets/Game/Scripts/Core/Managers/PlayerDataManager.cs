using UnityEngine;
using Google.Protobuf;
using System.IO;

namespace Game.Scripts.Core.Managers
{
    public class PlayerDataManager : MonoBehaviour
    {
        private const string savePath = "Assets/SavedData/player_data.protobuf";

        public void SavePlayerData(PlayerData playerData)
        {
            SerializeToFile(playerData, savePath);
            Debug.Log("Player data saved.");
        }

        public PlayerData LoadPlayerData()
        {
            PlayerData playerData = DeserializeFromFile<PlayerData>(savePath);
            Debug.Log("Player data loaded.");
            return playerData;
        }

        private void SerializeToFile(IMessage message, string filePath)
        {
            using (FileStream file = File.Create(filePath))
            {
                // Serialize the message to the file stream
                message.WriteTo(file);
            }
        }

        private T DeserializeFromFile<T>(string filePath) where T : IMessage<T>, new()
        {
            T message = new T();
            if (File.Exists(filePath))
            {
                using (FileStream file = File.OpenRead(filePath))
                {
                    // Deserialize the message from the file stream
                    message = (T)message.Descriptor.Parser.ParseFrom(file);
                }
            }
            return message;
        }
    }
}
