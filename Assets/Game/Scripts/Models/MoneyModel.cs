using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Models
{
    public class MoneyModel : MonoBehaviour
    {
        // Fields
        [SerializeField] private int _money;
        
        // State Events
        public event UnityAction<int> OnMoneyChanged;

        // Properties
        public int Money
        {
            get => _money;
            set => _money = value;
        }

        private void Start()
        {
            OnMoneyChanged?.Invoke(_money);
        }

        public void Spend(int value)
        {
            _money -= value;
            OnMoneyChanged?.Invoke(_money);
        }

        public void Receive(int value)
        {
            _money += value;
            OnMoneyChanged?.Invoke(_money);
        }
    }
}
