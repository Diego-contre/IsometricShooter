
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;

    private InteractableObject currentInteractable;
    [Header("Interaction UI")]
    public TextMeshProUGUI interactionText;

    void Update()
    {
        DetectInteractable();

        if (Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (currentInteractable != null)
            {
                currentInteractable.Interact();
            }
        }
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(currentInteractable != null);
            if (currentInteractable != null)
            {
                interactionText.text = "Presiona E para recoger " +
                                    currentInteractable.interactionName;
            }
        }
    }

    void DetectInteractable()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            interactionDistance
        );

        currentInteractable = null;

        foreach (Collider hit in hits)
        {
            InteractableObject interactable =
                hit.GetComponentInParent<InteractableObject>();

            if (interactable != null && interactable.canInteract)
            {
                currentInteractable = interactable;
                break;
            }
        }
    }
}
