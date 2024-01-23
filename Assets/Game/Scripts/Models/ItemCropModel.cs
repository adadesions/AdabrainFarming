using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Models
{
    public class ItemCropModel : MonoBehaviour
    {
        private int _watering;
        private bool _isGrowing = true;
        
        // State Events
        public event UnityAction<int> OnWateringChanged;
        public event UnityAction OnStoppedGrowing; 
        
        public int Watering
        {
            get => _watering;
            set
            {
                _watering = value;
                OnWateringChanged?.Invoke(_watering);
            }
        }

        public bool IsGrowing
        {
            get => _isGrowing;
            set
            {
                _isGrowing = value;
                if (!_isGrowing)
                {
                    OnStoppedGrowing?.Invoke();
                }
            }
        }

        private void Start()
        {
            OnWateringChanged?.Invoke(_watering);
        }
    }
}