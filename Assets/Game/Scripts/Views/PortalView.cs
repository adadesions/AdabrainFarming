using Game.Scripts.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views
{
    public class PortalView : MonoBehaviour
    {
        #region Fields

        private PortalPresenter _presenter;

        [SerializeField] private GameObject _loadingScreen;
        private Slider _progressSlider;

        #endregion;

        #region UnityAPIs

        private void Start()
        {
            _presenter = GetComponent<PortalPresenter>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Synchronize Loading 
                // _presenter.ChangeScene();
                
                // Asynchronize Loading
                _presenter.ChangeAsyncScene();
            }
        }

        #endregion

        #region Methods

        public void ShowLoadingScene(bool isShow)
        {
            var go = Instantiate(_loadingScreen, Vector3.zero, Quaternion.identity);
            _progressSlider = go.GetComponentInChildren<Slider>();
        }
        
        public void UpdateProgressSlider(float progress)
        {
            if (_progressSlider)
            {
                _progressSlider.value = progress;
            }
        }

        #endregion

    }
}