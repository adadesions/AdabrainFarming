using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Game.Scripts.Core.DataSheets
{
    [CreateAssetMenu(menuName = "AnimalData/Create AnimalData", fileName = "NewAnimalDataSheet", order = 0)]
    public class AnimalDataSheet : ScriptableObject
    {
        public string AnimalName;
        public int StartingAge = 1;
        public int LifeSpan = 8;
        public Vector2 ProductionAgeRange;
        public float BaseProductionRate = 8f;
        public float BaseGrowthRate = 20f;
        public AnimalFoodDataSheet FoodDataSheet;
        public List<float> GrowthPoints;
    }
}