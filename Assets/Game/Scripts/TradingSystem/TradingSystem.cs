using UnityEngine;

namespace Game.Scripts.TradingSystem
{
    public class TradingSystem : MonoBehaviour
    {
        public static void BuyItem(int price)
        {
            var playerMoney = PlayerPrefs.GetInt("Money");
            if (playerMoney >= price)
            {
                playerMoney -= price;
                PlayerPrefs.SetInt("Money", playerMoney);
            }
        }
    }
}
