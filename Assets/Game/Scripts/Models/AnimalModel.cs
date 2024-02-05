using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Models
{
    public class AnimalModel : MonoBehaviour
    {
        private bool _isWalk;
        [SerializeField] private string _animalName;
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _walkCooldown = 2f;
        
        // State Events
        public event UnityAction<bool> OnIsWalkChanged; 
        
        public bool IsWalk
        {
            get => _isWalk;
            set
            {
                _isWalk = value;
                OnIsWalkChanged?.Invoke(_isWalk);
            }
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float LastTimeWalk { get; set; }

        public float WalkCooldown
        {
            get => _walkCooldown;
            set => _walkCooldown = value;
        }

        public string Name
        {
            get => _animalName;
            set => _animalName = value;
        }
    }
}
