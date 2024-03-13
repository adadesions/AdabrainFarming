using Game.Scripts.DataTypes.SO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Models
{
    public class SpawnManagerModel : MonoBehaviour
    {
        [SerializeField] private SpawnLocationMasterListSO _spawnList;
        public Vector3 GetSpawnPosition()
        {
            var activeScene = SceneManager.GetActiveScene();
            var spawnSO = _spawnList.Find(activeScene.name);
            if (spawnSO)
            {
                return spawnSO.SpawnGO.transform.position;
            }

            return Vector3.zero;
        }
    }
}