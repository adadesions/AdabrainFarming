using System;
using Game.Scripts.InventorySystem;
using UnityEngine;

namespace Game.Scripts.Items
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [Serializable]
    public class CollectableItem : Item
    {
        private Rigidbody2D _rb2d;
        private Collider2D _collider2D;
        private Sprite _sprite;
        public string name;
        
        public ItemDescription Description
        {
            get => _itemDescription;
            set => _itemDescription = value;
        }

        private void Start()
        {
            name = _itemDescription.name;
            _rb2d = GetComponent<Rigidbody2D>();
            _rb2d.gravityScale = 0;
            _rb2d.freezeRotation = true;

            _collider2D = GetComponent<Collider2D>();
            _collider2D.isTrigger = true;
            _sprite = GetComponent<SpriteRenderer>().sprite;
            Initialization(_sprite);
        }

        public void Collect(Inventory inventory)
        {
            inventory.Add(this);
            Destroy(gameObject);
        }
        
        // Implement virtual method from parent
        // public override void Initialization(Sprite sprite)
        // {
        //     _itemDescription.sprite = sprite;
        //     print("Set Sprite!");
        // }
    }
}
