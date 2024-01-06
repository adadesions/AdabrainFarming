using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.Scripts.Items
{
    // Abstract Class
    [Serializable]
    public abstract class Item : MonoBehaviour
    {
        public string _name;
        
        [SerializeField] public ItemDescription _itemDescription;

        // Virtual Method
        public virtual void Initialization(Sprite sprite)
        {
            _itemDescription.sprite = sprite;
        }
    }
}
