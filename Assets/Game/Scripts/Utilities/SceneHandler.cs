using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Game.Scripts.Utilities
{
    public class SceneHandler : MonoBehaviour
    {
        #region Fields

        [SerializeField] private List<Object> _scenes;
        [SerializeField] private bool _isDebugging;
        [SerializeField] private Transform _spawnPosition;

        #endregion

        #region UnityAPIs

        private void OnEnable()
        {
            if (!_isDebugging)
            {
                LoadAdditiveScenes();
            }
        }

        #endregion

        #region Methods

        private void LoadAdditiveScenes()
        {
            foreach (var scene in _scenes)
            {
                SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);
            }
        }

        #endregion
    }
}
