using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{

    public Transform target; // The target the camera will follow
    public Vector3 offset; // The offset from the target position


    private void LateUpdate()
    {
        // Check if the target is assigned
        if (target != null)
        {
            // Update the camera's position based on the target's position and the offset
            transform.position = target.position + offset;
        }
    }
    
}
