using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Items
{
    public class ProductItem : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _itemPrefabs;
        [SerializeField] private int _numDropItems = 2;


        public void DropItem()
        {
            for (var i = 0; i < _numDropItems; i++)
            {
                var rand = Random.Range(0, _itemPrefabs.Count);
                var itemDropPos = transform.position + (i * Vector3.left);
                var itemClone = Instantiate(_itemPrefabs[rand], itemDropPos, Quaternion.identity);    
            }
        }
    }
}
