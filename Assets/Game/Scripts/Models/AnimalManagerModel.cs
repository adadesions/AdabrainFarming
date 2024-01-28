using UnityEngine;

namespace Game.Scripts.Models
{
    public class AnimalManagerModel : MonoBehaviour
    {
        [SerializeField] private GameObject _curAnimalPrefab;

        public GameObject CurAnimalPrefab
        {
            get => _curAnimalPrefab;
            set => _curAnimalPrefab = value;
        }
    }
}