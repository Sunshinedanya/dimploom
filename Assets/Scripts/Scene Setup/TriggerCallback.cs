using UnityEngine;
using UnityEngine.Events;

public class TriggerCallback : MonoBehaviour
{
    public UnityEvent<Collider> OnTriggered;

    private bool _triggered;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false)
            return;
        
        if (_triggered) 
            return;
        
        _triggered = true;
        OnTriggered.Invoke(other);
    }
}
