using System;
using UnityEngine;

namespace Game.Scripts.Views
{
    public class SpawnManagerView : MonoBehaviour
    {
        #region Fields

        private GameObject _player;

        #endregion

        #region UnityAPIs

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        #endregion

        #region Methods

        public void SetPlayerPosition(Vector3 position)
        {
            _player.transform.position = position;
        }

        #endregion
    }
}