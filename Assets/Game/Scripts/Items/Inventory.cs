using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Items
{
    public class Inventory : MonoBehaviour
    {
        private List<string> _itemList;

        public List<string> ItemList
        {
            get => _itemList;
            set => _itemList = value;
        }

        private void Start()
        {
            _itemList = new List<string>();
        }
    }
}
