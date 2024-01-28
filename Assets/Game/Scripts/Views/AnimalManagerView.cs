using UnityEngine;

namespace Game.Scripts.Views
{
    public class AnimalManagerView : MonoBehaviour
    {
        [SerializeField] private Transform _animalZone;

        public void InstantiateAnimals(GameObject animalPrefab)
        {
            var randPos = new Vector3(
                Random.Range(-8f, 8f), 
                Random.Range(14f, 20f), 
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