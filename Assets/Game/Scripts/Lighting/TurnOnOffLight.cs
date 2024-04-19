using System;
using Game.Scripts.Models;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game.Scripts.Lighting
{
    public class TurnOnOffLight : MonoBehaviour
    {
        private Light2D _light2d;

        void Awake()
        {
            _light2d = GetComponent<Light2D>();
            ClockModel.OnTimeOfDayChanged += OnTimeOfDayChanged;
        }

        private void OnDestroy()
        {
            ClockModel.OnTimeOfDayChanged -= OnTimeOfDayChanged;
        }

        private void OnTimeOfDayChanged(float timeOfDay)
        {
            if (timeOfDay > 0.25f && timeOfDay < 0.75f)
            {
                _light2d.enabled = false;
            }
            else
            {
                _light2d.enabled = true;
            }
        }
    }
}
