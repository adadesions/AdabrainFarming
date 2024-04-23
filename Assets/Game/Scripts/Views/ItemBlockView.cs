using UnityEngine;

namespace Game.Scripts.Views
{
    public class ItemBlockView : MonoBehaviour
    {
        public int Price;
        
        public void OnClick()
        {
            TradingSystem.TradingSystem.BuyItem(Price);
        }
    }
}
