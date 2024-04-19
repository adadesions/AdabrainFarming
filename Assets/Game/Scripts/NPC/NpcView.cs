using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.NPC
{
    public class NpcView : MonoBehaviour
    {
        public GameObject NpcCanvas;
        public TextMeshProUGUI DialogueText;
        
        public event UnityAction OnTalked;
        
        public void Talk()
        {
            NpcCanvas.SetActive(true);
            OnTalked?.Invoke();
        }

        public void UpdateDialogueText(string content)
        {
            DialogueText.text = content;
        }

        public void CloseDialogue()
        {
            NpcCanvas.SetActive(false);
        }
        
        public void OnClickNextButton()
        {
            OnTalked?.Invoke();
            print("click next button");
        }
    }
}