using Interactable;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public AudioSource audios;
    public GameObject? passwordTrigger;

    private bool _keyUsed = false;
    
    private void Awake()
    {
        audios = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        var hasKeys = Player.Player.instance.HasKeys;

        Debug.Log("interact");
        
        if (hasKeys == false)
        {
            DialogueController.instance.NewDialogueInstance("Дверь заперта, где то должен быть ключ");
            audios.Play();
        }
        else
        {
            //TODO Open door
            
            CheckActiveScene();
        }
    }

    public string GetDescription()
    {
        return "Открыть дверь";
    }

    private void CheckActiveScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            gameObject.SetActive(false);
            return;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            DialogueController.instance.NewDialogueInstance("Получилось открыть дверь! Но что это..");
            DialogueController.instance.NewDialogueInstance("Кодовый замок, придется ввести пароль");
            
            passwordTrigger.SetActive(true);
        }
    }
}
 