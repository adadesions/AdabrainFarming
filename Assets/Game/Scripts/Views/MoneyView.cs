using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Views
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyValueTMPro;

        // UI Events
        public event UnityAction<int> OnClickedSpendButton;
        public event UnityAction<int> OnClickedReceiveButton;
        
        public void UpdateMoneyBarUI(int newMoney)
        {
            _moneyValueTMPro.text = newMoney.ToString();
        }

        public void OnClickSpendButton(int spendValue)
        {
            OnClickedSpendButton?.Invoke(spendValue);
        }
        
        public void OnClickReceiveButton(int spendValue)
        {
            OnClickedReceiveButton?.Invoke(spendValue);
        }
    }
}