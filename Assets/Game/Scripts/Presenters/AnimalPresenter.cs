using System;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Presenters
{
    [RequireComponent(typeof(AnimalView))]
    [RequireComponent(typeof(AnimalModel))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class AnimalPresenter : MonoBehaviour
    {
        private AnimalModel _animalModel;
        private AnimalView _animalView;
        private Rigidbody2D _rb2d;
        private Vector2 _targetPos;

        private void Start()
        {
            _animalModel = GetComponent<AnimalModel>();
            _animalView = GetComponent<AnimalView>();
            _rb2d = GetComponent<Rigidbody2D>();
            
            // State Events
            _animalModel.OnIsWalkChanged += OnIsWalkChanged;
        }

        private void OnDestroy()
        {
            // State Events
            _animalModel.OnIsWalkChanged += OnIsWalkChanged;
        }

        private void FixedUpdate()
        {
            if (Time.time > _animalModel.LastTimeWalk + _animalModel.WalkCooldown)
            {
                _animalModel.LastTimeWalk = Time.time;
                var oddWalk = Random.Range(0f, 1f);
                if (oddWalk >= 0.3f)
                {
                    AnimalWalk();
                }
                else
                {
                    AnimalStop();
                }
            }
        }

        private void AnimalStop()
        {
            _rb2d.velocity = Vector2.zero;
            _animalModel.IsWalk = false;
        }

        private void AnimalWalk()
        {
            var directionX = Random.Range(-1.0f, 1.1f);
            _rb2d.velocity = new Vector2(directionX * _animalModel.Speed, _rb2d.velocity.y);
            _animalModel.IsWalk = true;
            _animalView.ChangeAnimationDirection(directionX);
        }

        private void OnIsWalkChanged(bool isWalk)
        {
            _animalView.SetIsWalk(isWalk);
        }
    }
}