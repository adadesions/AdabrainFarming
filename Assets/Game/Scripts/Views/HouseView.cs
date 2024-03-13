using System;
using Game.Scripts.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views
{
    public class HouseView : MonoBehaviour
    {
        #region Fields

        private HousePresenter _presenter;

        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Slider _progressSlider;

        #endregion;

        #region UnityAPIs

        private void Start()
        {
            _presenter = GetComponent<HousePresenter>();
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
            _loadingScreen.SetActive(isShow);
        }
        
        public void UpdateProgressSlider(float progress)
        {
            _progressSlider.value = progress;
        }

        #endregion

    }
}