using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Views
{
    public class SceneTriggerView : MonoBehaviour
    {
        public event UnityAction OnPlayerTriggerEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                print("Player Trigged");
                OnPlayerTriggerEnter?.Invoke();
            }
        }
    }
}