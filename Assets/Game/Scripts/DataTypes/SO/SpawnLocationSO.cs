using UnityEngine;

namespace Game.Scripts.DataTypes.SO
{
    [CreateAssetMenu(menuName = "SpawnLocation/Create SpawnLocationSO", fileName = "SpawnLocationSO")]
    public class SpawnLocationSO : ScriptableObject
    {
        public Object Scene;
        public GameObject SpawnGO;
    }
}