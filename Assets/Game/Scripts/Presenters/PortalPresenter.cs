using System.Collections;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Presenters
{
    public class PortalPresenter : MonoBehaviour
    {
        #region Fields

        private PortalModel _model;
        private PortalView _view;

        #endregion

        #region UnityAPIs

        private void Start()
        {
            _model = GetComponent<PortalModel>();
            _view = GetComponent<PortalView>();
        }

        #endregion

        #region Methods

        public void ChangeAsyncScene()
        {
            _view.ShowLoadingScene(true);
            StartCoroutine(LoadAsyncScene());
        }

        private IEnumerator LoadAsyncScene()
        {
            var sceneName = _model.DestinationSceneName;
            var asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                print("Loading progress " + asyncLoad.progress);

                var progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                _view.UpdateProgressSlider(progress);
                yield return null;
            }
            
            _view.ShowLoadingScene(false);
            
        }

        #endregion
    }
}