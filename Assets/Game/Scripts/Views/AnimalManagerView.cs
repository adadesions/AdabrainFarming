using UnityEngine;

namespace Game.Scripts.Views
{
    public class AnimalManagerView : MonoBehaviour
    {
        [SerializeField] private Transform _animalZone;
        [SerializeField] private Collider2D _animalZoneCollider;

        public void InstantiateAnimals(GameObject animalPrefab)
        {
            var boundary = _animalZoneCollider.bounds;
            var randPos = new Vector3(
                Random.Range(boundary.min.x, boundary.max.x), 
                Random.Range(boundary.min.y, boundary.max.y), 
                0);
            var animalClone = Instantiate(
                animalPrefab, randPos, Quaternion.identity);
            // animalClone.transform.localPosition = _animalZone.position + randPos;
        }

        public void InstantiateAnimals(GameObject animalPrefab, int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                InstantiateAnimals(animalPrefab);
            }
        }
    }
}