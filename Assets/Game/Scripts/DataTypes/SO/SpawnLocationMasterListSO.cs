using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.DataTypes.SO
{
    [CreateAssetMenu(menuName = "SpawnLocation/Create SpawnLocationMasterListSO", fileName = "SpawnLocationMasterListSO")]
    public class SpawnLocationMasterListSO : ScriptableObject
    {
        public List<SpawnLocationSO> SpawnLocationList;

        public SpawnLocationSO Find(string sceneName)
        {
            foreach (var so in SpawnLocationList)
            {
                if (so.Scene.name.Equals(sceneName))
                {
                    return so;
                }
            }

            return null;
        }
    }
}