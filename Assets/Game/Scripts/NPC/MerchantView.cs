using System;
using Game.Scripts.Views;
using Resources.SOData.ItemsData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.NPC
{
    public class MerchantView : MonoBehaviour
    {
        [SerializeField] private GameObject _shopPanelLayout;

        public event UnityAction OnShopPanelOpened;
        
        public void ShowShopPanel(ItemDataSO itemData)
        {
            print("Show shop panel");
            gameObject.SetActive(true);
            // OnShopPanelOpened?.Invoke();
            GenerateShopItems(itemData);            
        }

        public void GenerateShopItems(ItemDataSO itemData)
        {
            var itemLength = itemData.itemNames.Count;
            for (var i = 0; i < itemLength; i++)
            {
                var go = Instantiate(
                    itemData.ShopItemPrefab,
                    _shopPanelLayout.transform
                    );

                go.GetComponent<ItemBlockView>().Price = itemData.itemCosts[i];
                go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemData.itemNames[i];
                go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemData.itemCosts[i].ToString();
            }
        }
    }
}