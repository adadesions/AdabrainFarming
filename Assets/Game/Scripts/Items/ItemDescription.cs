using System;
using UnityEngine;

namespace Game.Scripts.Items
{
    [CreateAssetMenu(fileName = "New Item Description", menuName = "Item/Item Description")]
    [Serializable]
    public class ItemDescription : ScriptableObject
    {
        public string itemName = "Item Name";
        public float dropRate = 0.3f;
        public Sprite sprite;
    }
}
