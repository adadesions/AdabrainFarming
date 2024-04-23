using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.NPC
{
    public class NpcView : MonoBehaviour
    {
        public GameObject NpcCanvas;
        public TextMeshProUGUI DialogueText;
        public GameObject DialoguePanel;
        
        public event UnityAction OnTalked;
        public static event UnityAction OnClosedDialogue;
        
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
            DialoguePanel.SetActive(false);
            OnClosedDialogue?.Invoke();
        }
        
        public void OnClickNextButton()
        {
            OnTalked?.Invoke();
            print("click next button");
        }
    }
}