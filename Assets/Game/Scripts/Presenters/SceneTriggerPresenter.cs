using System;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Presenters
{
    public class SceneTriggerPresenter : MonoBehaviour
    {
        private SceneTriggerModel _model;
        private SceneTriggerView _view;

        private void Start()
        {
            _model = GetComponent<SceneTriggerModel>();
            _view = GetComponent<SceneTriggerView>();
            
            _view.OnPlayerTriggerEnter += OnPlayerTriggerEnter;
        }

        private void OnDestroy()
        {
            _view.OnPlayerTriggerEnter -= OnPlayerTriggerEnter;
        }

        private void OnPlayerTriggerEnter()
        {
            var sceneName = _model.SceneName;

            if (_model.IsLoaded)
            {
                SceneManager.UnloadSceneAsync(sceneName);
            }
            else
            {
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }

            _model.IsLoaded = !_model.IsLoaded;

        }
    }
}