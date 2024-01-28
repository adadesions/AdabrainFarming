using System;
using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;

namespace Game.Scripts.Presenters
{
    [RequireComponent(typeof(AnimalManagerView))]
    [RequireComponent(typeof(AnimalManagerModel))]
    public class AnimalManagerPresenter : MonoBehaviour
    {
        private AnimalManagerModel _animalManagerModel;
        private AnimalManagerView _animalManagerView;
        
        private void Start()
        {
            _animalManagerModel = GetComponent<AnimalManagerModel>();
            _animalManagerView = GetComponent<AnimalManagerView>();
            
            _animalManagerView.InstantiateAnimals(_animalManagerModel.CurAnimalPrefab, 10);
        }
    }
}