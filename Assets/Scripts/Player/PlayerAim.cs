
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public WeaponController weaponController;
    public Camera mainCamera;

    
   

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);

            Vector3 direction = hitPoint - transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }



        // Shoot weapon when left mouse button is pressed
        if (weaponController.currentWeapon != null)
        {
            bool automatic = weaponController.currentWeapon.weaponData.automaticFire;

            if (automatic && Mouse.current.leftButton.isPressed)
            {
                weaponController.Shoot();
            }
            else if (!automatic && Mouse.current.leftButton.wasPressedThisFrame)
            {
                weaponController.Shoot();
            }
        }


        // Reload weapon when 'R' key is pressed
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            weaponController.currentWeapon.Reload(); 
        }
    }

    
}
