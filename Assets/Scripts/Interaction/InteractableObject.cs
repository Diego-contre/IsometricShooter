
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Interaction Settings")]
    public string interactionName;
    public bool canInteract = true;

    public virtual void Interact()
    {
        Debug.Log("Interactuando con: " + interactionName);
    }
}