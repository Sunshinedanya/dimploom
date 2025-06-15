using Interactable;
using UnityEngine;

public class MirrorInteract : MonoBehaviour, IInteractable
{
    private bool broken = false;

    [SerializeField] private GameObject _mirror;
    [SerializeField] private AudioSource _audioSource;
    public void Interact()
    {
    }

    public string GetDescription()
    {
        if(broken != false)
            return "";
        
        broken = true;
        BreakGlass();
        return "";
    }

    private void BreakGlass()
    {
        _mirror.gameObject.SetActive(false);
        _audioSource.Play();
    }
}
