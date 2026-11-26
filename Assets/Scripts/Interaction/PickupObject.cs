
using UnityEngine;

public class PickupObject : InteractableObject
{
    public override void Interact()
    {
        if (!canInteract)
            return;

        Debug.Log("Objeto recogido: " + interactionName);

        Destroy(gameObject);
    }
}
