
using UnityEngine;

public class WeaponPickup : PickupObject
{
    [Header("Weapon Settings")]
    public WeaponBase weapon;
    [Header("Player References")]
    public WeaponController weaponController;

    public override void Interact()
{
    if (!canInteract || weapon == null || weaponController == null)
        return;

    weaponController.EquipWeapon(weapon);

    Debug.Log("Arma equipada: " + weapon.weaponData.weaponName);

    base.Interact();
}
}
