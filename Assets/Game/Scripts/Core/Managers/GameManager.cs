using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Core.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        private int _curDay;
        [SerializeField] private float _secondsPerDay = 5.0f;
        
        // Pools Setting
        [SerializeField] private GameObject _itemPool;
        

        public event UnityAction OnDayChanged;

        public static GameManager Instance
        {
            get => _instance;
            private set => _instance = value;
        }

        public int CurrentDay
        {
            get => _curDay;
            set => _curDay = value;
        }

        public GameObject ItemPool
        {
            get => _itemPool;
            set => _itemPool = value;
        }

        private void Awake()
        {
            if (_instance != this && _instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            print($"Current Day: {_curDay} days");
            StartCoroutine(UpdateDay());
        }

        private IEnumerator UpdateDay()
        {
            while (true)
            {
                yield return new WaitForSeconds(_secondsPerDay);
                _curDay++;
                OnDayChanged?.Invoke();
                print($"Current Day: {_curDay} days");
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
