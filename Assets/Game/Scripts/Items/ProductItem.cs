using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Items
{
    public class ProductItem : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _itemPrefabs;
        [SerializeField] private int _numDropItems = 2;

        private List<Vector3> _dropDirection = new List<Vector3>
        {
            Vector3.left,
            Vector3.right,
            Vector3.up,
            Vector3.down
        };


        public void DropItem()
        {
            for (var i = 0; i < _numDropItems; i++)
            {
                var rand = Random.Range(0, _itemPrefabs.Count);
                
                if (!IsReachDropRate(_itemPrefabs[rand])) return;
                
                var itemDropPos = transform.position + _dropDirection[i];
                var itemClone = Instantiate(_itemPrefabs[rand], itemDropPos, Quaternion.identity);    
            }
        }

        private static bool IsReachDropRate(GameObject item)
        {
            var collectableItemComp = item.GetComponent<CollectableItem>();
            var itemDescription = collectableItemComp.Description;
            return Random.value < itemDescription.dropRate;
        }
    }
}
