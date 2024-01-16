using System;
using System.Runtime.Serialization;
using Game.Scripts.Items;
using UnityEngine;

namespace Game.Scripts.InventorySystem
{
    [Serializable]
    public class InventoryItem : ISerializable
    {
        public CollectableItem _item;
        public int _quantity;
        
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_quantity", _quantity);
        }
    }
}
