using System.Collections.Generic;
using UnityEngine;

namespace Resources.SOData.ItemsData
{
    [CreateAssetMenu(menuName = "Create ItemDataSO", fileName = "ItemDataSO")]
    public class ItemDataSO : ScriptableObject
    {
        public string npcName;
        public List<string> itemNames;
        public List<int> itemCosts;
        public GameObject ShopItemPrefab;
    }
}
