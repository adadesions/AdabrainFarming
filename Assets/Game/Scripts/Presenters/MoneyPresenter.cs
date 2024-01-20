using System;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;

namespace Game.Scripts.Presenters
{
    public class MoneyPresenter : MonoBehaviour
    {
        private MoneyModel _moneyModel;
        private MoneyView _moneyView;

        private void Start()
        {
            _moneyModel = GetComponent<MoneyModel>();
            _moneyView = GetComponent<MoneyView>();
            
            // State Events
            _moneyModel.OnMoneyChanged += OnMoneyChanged;
            
            // UI Events
            _moneyView.OnClickedSpendButton += OnClickedSpendButton;
            _moneyView.OnClickedReceiveButton += OnClickedReceiveButton;
        }

        private void OnDestroy()
        {
            _moneyModel.OnMoneyChanged -= OnMoneyChanged;
            _moneyView.OnClickedSpendButton -= OnClickedSpendButton;
            _moneyView.OnClickedReceiveButton -= OnClickedReceiveButton;
        }

        private void OnClickedReceiveButton(int receiveValue)
        {
            _moneyModel.Receive(receiveValue);
        }

        private void OnClickedSpendButton(int spendValue)
        {
            _moneyModel.Spend(spendValue);
        }

        private void OnMoneyChanged(int newMoney)
        {
            _moneyView.UpdateMoneyBarUI(newMoney);
        }
    }
}