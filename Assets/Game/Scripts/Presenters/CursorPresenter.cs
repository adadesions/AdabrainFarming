using System;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;

namespace Game.Scripts.Presenters
{
    public class CursorPresenter : MonoBehaviour
    {
        private CursorModel _cursorModel;
        private CursorView _cursorView;

        private void Start()
        {
            _cursorModel = GetComponent<CursorModel>();
            _cursorView = GetComponent<CursorView>();
        }
    }
}