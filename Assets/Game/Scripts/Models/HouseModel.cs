using UnityEngine;

namespace Game.Scripts.Models
{
    public class HouseModel : MonoBehaviour
    {
        [SerializeField] 
        private int _destSceneBuildIdx;


        public int DestSceneBuildIdx
        {
            get => _destSceneBuildIdx;
            set => _destSceneBuildIdx = value;
        }
    }
}