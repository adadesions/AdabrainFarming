using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.SpecialScene.SO_Data
{
    public class DoorHandler : MonoBehaviour
    {
        [SerializeField] private string _curMap;
        [SerializeField] private string _nextMap;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.UnloadSceneAsync(_curMap);
                SceneManager.LoadScene(_nextMap, LoadSceneMode.Additive);
            }
                
        }
    }
}
