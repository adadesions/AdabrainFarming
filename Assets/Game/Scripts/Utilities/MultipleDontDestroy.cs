using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Utilities
{
    public class MultipleDontDestroy : MonoBehaviour
    {
        [SerializeField] 
        private List<GameObject> _dontDestroyList;
        
        [SerializeField] 
        private bool _isDontDestroyThis;

        #region UnityAPIs

        private void Awake()
        {
            foreach (var go in _dontDestroyList)
            {
                DontDestroyOnLoad(go);
            }

            if (_isDontDestroyThis)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        #endregion
    }
}