using System;
using UnityEngine;

namespace Game.Scripts.Views
{
    public class ItemCropView : MonoBehaviour
    {
        private GameObject _wateringIcon;
        private GameObject _stopGrowingIcon;

        private void Awake()
        {
            _wateringIcon = transform.Find("WateringCanIcon").gameObject;
            _stopGrowingIcon = transform.Find("StopGrowingIcon").gameObject;
        }

        public void ShowWateringIcon(bool isShow)
        {
            _wateringIcon.SetActive(isShow);
        }

        public void ShowStopGrowingIcon(bool isShow)
        {
            _stopGrowingIcon.SetActive(isShow);
        }
    }
}