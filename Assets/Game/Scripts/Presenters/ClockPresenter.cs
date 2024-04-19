using System;
using Game.Scripts.DataTypes.SO;
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
            _model.OnStarted += OnStarted;
            _model.OnCurrentDayChanged += OnCurrentDayChanged;
            _model.OnCurrentTimeChaged += OnTimeOfDayChanged;
        }


        private void OnDestroy()
        {
            _model.OnCurrentDayChanged -= OnCurrentDayChanged;
        }

        private void OnStarted(WeatherDataSO weatherDataSO)
        {
            _view.UpdateCalendarDisplay(weatherDataSO.CurrentDay, weatherDataSO.GetCurrentDaySprite());
            _view.UpdateDate(weatherDataSO.CurrentDay);
        }
        
        private void OnTimeOfDayChanged(float timeOfDay)
        {
            _view.UpdateTime(timeOfDay);
            
            var weatherDataSO = _model.WeatherData;
            // var color = Color.Lerp(
            //     weatherDataSO.midnightColor,
            //     weatherDataSO.noonColor,
            //     Mathf.Sin(timeOfDay * Mathf.PI)
            //     );

            Color color;
            // var step = Mathf.Abs(Mathf.Sin(timeOfDay * Mathf.PI));
            var step = timeOfDay;
            if (step < 0.33f)
            {
                color = Color.Lerp(weatherDataSO.midnightColor, weatherDataSO.morningColor, step * 3);
            }
            else if (step < 0.66f)
            {
                color = Color.Lerp(weatherDataSO.morningColor, weatherDataSO.noonColor, (step - 0.33f) * 3 );
            }
            else
            {
                color = Color.Lerp(weatherDataSO.noonColor, weatherDataSO.midnightColor, (step - 0.66f) * 3 );
            }
            
            _view.UpdateColorOfLight(timeOfDay, color);
        }

        private void OnCurrentDayChanged(int currentDay)
        {
            var daySprite = _model.GetCurrentDaySprite();
            _view.UpdateCalendarDisplay(currentDay, daySprite);
            _view.UpdateDate(currentDay);
        }
    }
}