using TMPro;
using UnityEngine;

namespace Scenes.SpecialScene.SO_Data
{
    
    [CreateAssetMenu(menuName = "Create PlayerDataSO", fileName = "PlayerDataSO", order = 0)]
    public class PlayerDataSO : ScriptableObject
    {
        public string PlayerName;
        public int Health;
        public GameObject LoadingScene;
    }
}
