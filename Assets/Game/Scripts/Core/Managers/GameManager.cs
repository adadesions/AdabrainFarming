using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Core.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Fields

        private static GameManager _instance;
        private int _curDay;
        private GameObject _player;
        private Animator _playerAnimator;

        #region SerializeFields

        [SerializeField] private float _secondsPerDay = 5.0f;
        // Pools Setting
        [SerializeField] private GameObject _itemPool;

        #endregion
        
        #endregion


        #region Events Fields
        public static event UnityAction OnDayChanged;

        #endregion

        #region Properties

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

        #endregion

        #region UnityAPIs

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
            _player = GameObject.FindWithTag("Player");
            _playerAnimator = _player.GetComponent<Animator>();
            
            print($"Current Day: {_curDay} days");
            StartCoroutine(UpdateDay());
        }

        #endregion

        #region Methods

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

        public Animator GetPlayerAnimator()
        {
            return _playerAnimator;
        }

        public Vector2 GetPlayerPosition()
        {
            return (Vector2) _player.transform.position;
        }

        #endregion
    }
}
