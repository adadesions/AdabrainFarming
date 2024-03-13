using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Scripts.Models
{
    public class PortalModel : MonoBehaviour
    {
        [SerializeField] private Object _scene;
        private string _destSceneName;

        public string DestinationSceneName
        {
            get => _destSceneName;
            set => _destSceneName = value;
        }

        private void Awake()
        {
            _destSceneName = _scene.name;
        }
    }
}