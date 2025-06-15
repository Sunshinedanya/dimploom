using System;
using Interactable;
using TMPro;
using UnityEngine;

public class InteractComponent : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 10f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    public LayerMask interactionLayerMask;
    private void Update()
    {
        InteractionRay(Input.GetKeyDown(KeyCode.E));
    }

    private void InteractionRay(bool interact)
    {
        var ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        var hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayerMask))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            if (interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();
                
                if (interact)
                {
                   interactable.Interact();
                }
            }
        }
        
        interactionUI.SetActive(hitSomething);
    }
}
