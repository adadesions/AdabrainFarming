using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Items
{
    [CreateAssetMenu(fileName = "Item Crop Data", menuName = "Item/Item Crop Data")]
    public class ItemCropData : ScriptableObject
    {
        public List<Sprite> ProgressSprites;
        public Sprite ReadyToHarvestSprites;
        public int DaysGrowth;
    }
}
