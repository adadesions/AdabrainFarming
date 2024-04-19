using System;
using System.Collections;
using Game.Scripts.DataTypes.SO;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Models
{
    public class ClockModel : MonoBehaviour
    {
        [SerializeField] private WeatherDataSO _weatherDataSO;
        private float _lastDayChanged;
        private float _changeDayCoolDown = 0.5f;

        public event UnityAction<int> OnCurrentDayChanged;
        public event UnityAction<WeatherDataSO> OnStarted;
        public event UnityAction<float> OnCurrentTimeChaged;
        
        public static event UnityAction<float> OnTimeOfDayChanged; 

        public WeatherDataSO WeatherData
        {
            get => _weatherDataSO;
            set => _weatherDataSO = value;
        }


        private void Start()
        {
            OnStarted?.Invoke(WeatherData);
            StartCoroutine(RunMyFarmTime());
        }

        private IEnumerator RunMyFarmTime()
        {
            while (true)
            {
                var dayLength = WeatherData.DayLengthInMinutes * 60;
                var timeIncrement = Time.deltaTime / dayLength;
                WeatherData.TimeOfDay = Mathf.Repeat(WeatherData.TimeOfDay + timeIncrement, 1.0f);
                
                OnCurrentTimeChaged?.Invoke(WeatherData.TimeOfDay);
                OnTimeOfDayChanged?.Invoke(WeatherData.TimeOfDay);
                
                if (WeatherData.TimeOfDay >= 0.999f && Time.time > _lastDayChanged + _changeDayCoolDown)
                {
                    WeatherData.CurrentDay++;
                    OnCurrentDayChanged?.Invoke(WeatherData.CurrentDay);
                    
                    _lastDayChanged = Time.time;
                }

                yield return null;
            }
        }

        public Sprite GetCurrentDaySprite()
        {
            return WeatherData.GetCurrentDaySprite();
        }
    }
}