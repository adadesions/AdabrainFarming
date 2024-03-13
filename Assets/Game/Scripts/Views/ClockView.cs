using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views
{
    public class ClockView : MonoBehaviour
    {
        [SerializeField] private Image _daySpriteUI;

        public void UpdateCalendarDisplay(int currentDay, Sprite daySprite)
        {
            _daySpriteUI.sprite = daySprite;
            print(currentDay);
        }
    }
}