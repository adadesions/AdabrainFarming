using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.DataTypes.SO
{
    [CreateAssetMenu(menuName = "Create WeatherDataSO", fileName = "WeatherDataSO")]
    public class WeatherDataSO : ScriptableObject
    {
        public List<Sprite> DaysSprites;
        public int CurrentDay;
        public float CurrentTime;
        public float aDayDurationInSeconds = 1f;
        public float DayLengthInMinutes = 3.0f;
        public float TimeOfDay;
        public Color morningColor;
        public Color noonColor;
        public Color midnightColor;

        public Sprite GetCurrentDaySprite()
        {
            CurrentDay = CurrentDay <= 0 ? 1 : CurrentDay;
            return DaysSprites[ (CurrentDay-1) % DaysSprites.Count ];
        }
    }
}
