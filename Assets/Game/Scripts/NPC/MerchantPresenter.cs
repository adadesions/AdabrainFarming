using System;
using UnityEngine;

namespace Game.Scripts.NPC
{
    public class MerchantPresenter : MonoBehaviour
    {
        private MerchantModel _model;
        private MerchantView _view;

        private void Awake()
        {
            _model = GetComponent<MerchantModel>();
            _view = GetComponent<MerchantView>();
        }

        private void OnEnable()
        {
            _view.OnShopPanelOpened += OnShopPanelOpened;
            NpcView.OnClosedDialogue += OnClosedDialogue;
        }

        private void OnDestroy()
        {
            _view.OnShopPanelOpened -= OnShopPanelOpened;
            NpcView.OnClosedDialogue -= OnClosedDialogue;
        }

        private void OnClosedDialogue()
        {
            _view.ShowShopPanel(_model.ItemData);
        }

        private void OnShopPanelOpened()
        {
            _view.GenerateShopItems(_model.ItemData);
        }
    }
}