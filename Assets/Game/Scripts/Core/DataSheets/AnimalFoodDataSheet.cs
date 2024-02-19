using UnityEngine;

namespace Game.Scripts.Core.DataSheets
{
    [CreateAssetMenu(menuName = "AnimalData/Create AnimalFood", fileName = "NewAnimalFoodDataSheet", order = 0)]
    public class AnimalFoodDataSheet : ScriptableObject
    {
        public string FoodName;
        public Sprite FoodSprite;
        public float GrowthModifier = 2f;
        public float ProductionModifier = 1.5f;
        public float Satiety = 5f;
    }
}