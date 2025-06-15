using UnityEngine;
using UnityEngine.Events;

public class PortalTrigger : MonoBehaviour
{
    public UnityEvent OnPortalEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        OnPortalEnter.Invoke();
    }
}
