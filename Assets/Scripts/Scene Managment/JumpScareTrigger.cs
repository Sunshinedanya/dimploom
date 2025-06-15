using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        DialogueController.instance.ClearDialogueInstance();
        DialogueController.instance.NewDialogueInstance("[EXAGGERATE]что происходит с зеркалом[/EXAGGERATE]");
        gameObject.SetActive(false);
    }
}