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

        public event UnityAction<int> OnCurrentDayChanged; 
        
        private void Start()
        {
            StartCoroutine(RunMyFarmTime());
        }

        private IEnumerator RunMyFarmTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(_weatherDataSO.aDayDurationInMins * 60f);
                _weatherDataSO.CurrentDay++;
                OnCurrentDayChanged?.Invoke(_weatherDataSO.CurrentDay);
            }
            yield return null;
        }

        public Sprite GetCurrentDaySprite()
        {
            return _weatherDataSO.GetCurrentDaySprite();
        }
    }
}