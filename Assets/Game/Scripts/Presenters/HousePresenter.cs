using System;
using System.Collections;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Presenters
{
    public class HousePresenter : MonoBehaviour
    {
        #region Fields

        private HouseModel _model;
        private HouseView _view;

        #endregion

        #region UnityAPIs

        private void Start()
        {
            _model = GetComponent<HouseModel>();
            _view = GetComponent<HouseView>();
        }

        #endregion

        #region Methods

        public void ChangeScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void ChangeAsyncScene()
        {
            _view.ShowLoadingScene(true);
            StartCoroutine(LoadAsyncScene());
        }

        private IEnumerator LoadAsyncScene()
        {
            var sceneIndex = _model.DestSceneBuildIdx;
            var asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

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