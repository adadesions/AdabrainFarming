using System;
using UnityEngine;

namespace Game.Scripts.Items
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CollectableItem : MonoBehaviour
    {
        private Rigidbody2D _rb2d;
        private Collider2D _collider2D;

        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _rb2d.gravityScale = 0;
            _rb2d.freezeRotation = true;

            _collider2D = GetComponent<Collider2D>();
            _collider2D.isTrigger = true;
        }
    }
}
