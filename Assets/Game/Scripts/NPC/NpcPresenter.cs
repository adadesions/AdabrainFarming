using System;
using UnityEngine;

namespace Game.Scripts.NPC
{
    public class NpcPresenter : MonoBehaviour
    {
        private NpcView _npcView;
        private NpcModel _npcModel;

        private void Awake()
        {
            _npcView = GetComponent<NpcView>();
            _npcModel = GetComponent<NpcModel>();
            
            _npcView.OnTalked += OnTalked;

            _npcModel.OnTalkedEnd += OnTalkedEnd;
        }

        private void OnDestroy()
        {
            _npcView.OnTalked -= OnTalked;
            _npcModel.OnTalkedEnd -= OnTalkedEnd;
        }

        private void OnTalkedEnd()
        {
            _npcView.CloseDialogue();
        }

        private void OnTalked()
        {
            _npcView.UpdateDialogueText(_npcModel.GetCurrentDialogue());
        }
    }
}