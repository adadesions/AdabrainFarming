using Game.Scripts.NPC.DataSO;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.NPC
{
    public class NpcModel : MonoBehaviour
    {
        public NpcMerchantModelSO NpcMerchantModelSo;
        private int _currentIndexDialogue;
        
        public event UnityAction OnTalkedEnd;

        public string GetCurrentDialogue()
        {
            var dialogueLength = NpcMerchantModelSo.Dialogues.Count;
            if (_currentIndexDialogue >= dialogueLength)
            {
                _currentIndexDialogue = 0;
                OnTalkedEnd?.Invoke();
                return "";
            }
            
            var dialogue = NpcMerchantModelSo.Dialogues[_currentIndexDialogue %  dialogueLength];
            _currentIndexDialogue++;

            return dialogue;
        }
    }
}
