using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Scripts.Models
{
    public class SceneTriggerModel : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Object _scene;
        private string _sceneName;
        private bool _isLoaded;

        #endregion

        #region Properties

        public string SceneName
        {
            get => _sceneName;
            set => _sceneName = value;
        }

        public bool IsLoaded
        {
            get => _isLoaded;
            set => _isLoaded = value;
        }

        #endregion

        #region UnityAPIs

        private void Awake()
        {
            SceneName = _scene.name;
        }

        #endregion
    }
}