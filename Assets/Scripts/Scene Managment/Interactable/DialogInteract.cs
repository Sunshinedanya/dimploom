using Dialog.Model;
using UnityEngine;

namespace Interactable
{
    public class DialogInteract : MonoBehaviour, IInteractable
    {
        [SerializeField] private string characterId;
        
        [SerializeField] private DialogVariant dialog;
        
        public void Interact()
        {
            foreach (var response in dialog.responses)
            {
                DialogueController.instance.NewDialogueInstance(response, characterId);
            }
        }

        public string GetDescription()
        {
            return "Поговорить";
        }
    }
}