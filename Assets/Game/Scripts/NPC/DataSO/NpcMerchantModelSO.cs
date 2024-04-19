using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.NPC.DataSO
{
    [CreateAssetMenu(menuName = "Create Npc Merchant", fileName = "New Npc Merchant")]
    public class NpcMerchantModelSO : ScriptableObject
    {
        public string Name;
        public List<string> Dialogues;
    }
}