using System;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;

namespace Game.Scripts.Presenters
{
    public class SpawnManagerPresenter : MonoBehaviour
    {
        #region Fields

        private SpawnManagerModel _model;
        private Vector3 _curScenePos;
        private SpawnManagerView _view;

        #endregion

        #region UnityAPIs

        private void Awake()
        {
            _model = GetComponent<SpawnManagerModel>();
            _view = GetComponent<SpawnManagerView>();

            _curScenePos = _model.GetSpawnPosition();
            _view.SetPlayerPosition(_curScenePos);
        }

        #endregion
    }
}