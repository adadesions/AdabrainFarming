using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace Game.Scripts.Views
{
    public class ClockView : MonoBehaviour
    {
        [SerializeField] private Image _daySpriteUI;
        [SerializeField] private TextMeshProUGUI _dateText;
        [SerializeField] private TextMeshProUGUI _hhTimeText;
        [SerializeField] private TextMeshProUGUI _mmTimeText;
        [SerializeField] private Light2D _globalLight;

        public void UpdateCalendarDisplay(int currentDay, Sprite daySprite)
        {
            _daySpriteUI.sprite = daySprite;
            print(currentDay);
        }

        public void UpdateDate(int currentDay)
        {
            var calendarDate = currentDay % 30;
            if (calendarDate == 0)
            {
                calendarDate = 30;
            }
            _dateText.text = calendarDate.ToString();
        }
        
        public void UpdateTime(float timeOfDay)
        {
            var hour = Mathf.FloorToInt(timeOfDay * 24f);
            var minute = Mathf.FloorToInt((timeOfDay * 24f - hour) * 60f);
            
            _hhTimeText.text = $"{hour:D2}";
            _mmTimeText.text = $"{minute:D2}";
        }

        public void UpdateColorOfLight(float timeOfDay, Color color)
        {
            _globalLight.color = color;
        }
    }
}