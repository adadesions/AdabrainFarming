using System;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Views
{
    public class MoneyUIView : MonoBehaviour
    {
        private TextMeshProUGUI _moneytext;

        private void Start()
        {
            _moneytext = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (PlayerPrefs.HasKey("Money"))
            {
                _moneytext.text = PlayerPrefs.GetInt("Money").ToString();
            }
        }
    }
}