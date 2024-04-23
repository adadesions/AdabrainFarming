using Resources.SOData.ItemsData;
using UnityEngine;

namespace Game.Scripts.NPC
{
    public class MerchantModel : MonoBehaviour
    {
        [SerializeField] private ItemDataSO _itemDataSO;


        public ItemDataSO ItemData
        {
            get => _itemDataSO;
            set => _itemDataSO = value;
        }
    }
}