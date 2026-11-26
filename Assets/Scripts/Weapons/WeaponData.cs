
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Weapon Information")]
    public string weaponName;
    

    

    [Header("Shooting")]
    public GameObject projectilePrefab;
    public float fireRate = 0.3f;
    public int damage = 10;
    public bool automaticFire = false;

    [Header("Ammunition")]
    public int magazineSize = 12;
    public float reloadTime = 1.5f;

    [Header("Projectile Settings")]
    public int projectilesPerShot = 1;
    public float spreadAngle = 0f;
}
