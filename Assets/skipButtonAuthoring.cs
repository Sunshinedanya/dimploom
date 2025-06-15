using UnityEngine;
using UnityEngine.UI;

public class skipButtonAuthoring : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener((() =>
        {
            DialogueController.instance.ClearDialogueInstance();
        }));
    }
}
