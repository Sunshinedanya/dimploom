using UnityEngine;

namespace Interactable
{
    public class PickUpItem : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Player.Player.instance.ArtefactPickUp();
            gameObject.SetActive(false);

            var artefactsLeft = 3 - Player.Player.instance.ArtCount;
            
            if(artefactsLeft > 0)
                DialogueController.instance.NewDialogueInstance($"Осталось найти {artefactsLeft} артефакта");
            else
                DialogueController.instance.NewDialogueInstance($"Это должны быть все артефакты");

        }

        public string GetDescription()
        {
            return "Подобрaть артефакт";
        }
    }
}