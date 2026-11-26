using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Setup")]
    public WeaponBase currentWeapon;
    public WeaponBase[] availableWeapons;
    

    void Start()
    {
        WeaponBase startingWeapon = currentWeapon;

        // Desactivar todas las armas inicialmente
        foreach (WeaponBase weapon in availableWeapons)
        {
            if (weapon != null)
                weapon.gameObject.SetActive(false);
        }

        // Equipar el arma inicial
        if (startingWeapon == null && availableWeapons.Length > 0)
            startingWeapon = availableWeapons[0];

        EquipWeapon(startingWeapon);
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            EquipWeapon(availableWeapons[0]);

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            EquipWeapon(availableWeapons[1]);

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            EquipWeapon(availableWeapons[2]);
    }

    public void EquipWeapon(WeaponBase newWeapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }

        currentWeapon = newWeapon;

        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(true);
        }
    }

    public void Shoot()
    {
        if (currentWeapon != null)
        {
            currentWeapon.Shoot();
        }
    }
}