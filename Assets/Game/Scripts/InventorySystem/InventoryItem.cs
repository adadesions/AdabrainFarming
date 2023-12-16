using Game.Scripts.Items;
using UnityEngine;

namespace Game.Scripts.InventorySystem
{
    public class InventoryItem
    {
        private CollectableItem _item;
        private int _quantity;
        
        // Constructors
        public InventoryItem(CollectableItem item, int quantity)
        {
            ItemObject = item;
            Quantity = quantity;
        }

        public CollectableItem ItemObject
        {
            get => _item;
            set => _item = value;
        }

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
    }
}
