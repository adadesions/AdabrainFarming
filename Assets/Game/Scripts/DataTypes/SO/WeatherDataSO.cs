using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.DataTypes.SO
{
    [CreateAssetMenu(menuName = "Create WeatherDataSO", fileName = "WeatherDataSO")]
    public class WeatherDataSO : ScriptableObject
    {
        public List<Sprite> DaysSprites;
        public int CurrentDay;
        public float aDayDurationInMins;

        public Sprite GetCurrentDaySprite()
        {
            return DaysSprites[CurrentDay % 7 - 1];
        }
    }
}
