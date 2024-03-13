using System;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;

namespace Game.Scripts.Presenters
{
    [RequireComponent(typeof(ClockView))]
    [RequireComponent(typeof(ClockModel))]
    public class ClockPresenter : MonoBehaviour
    {
        private ClockModel _model;
        private ClockView _view;

        private void OnEnable()
        {
            _model = GetComponent<ClockModel>();
            _view = GetComponent<ClockView>();
            
            // State-Events
            _model.OnCurrentDayChanged += OnCurrentDayChanged;
        }

        private void OnDestroy()
        {
            _model.OnCurrentDayChanged -= OnCurrentDayChanged;
        }

        private void OnCurrentDayChanged(int currentDay)
        {
            var daySprite = _model.GetCurrentDaySprite();
            _view.UpdateCalendarDisplay(currentDay, daySprite);
        }
    }
}