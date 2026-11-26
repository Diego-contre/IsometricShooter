
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [Header("Weapon Configuration")]
    //Referencia al ScriptableObject que contiene los datos del arma
    public WeaponData weaponData;

    [Header("References")]
    public Transform firePoint;

    protected float nextFireTime;

    [Header("Ammunition")]
    public int currentAmmo;
    public bool isReloading = false;

    public float reloadProgress = 0f;
    private float reloadStartTime;

    void Start()
    {
        currentAmmo = weaponData.magazineSize;
    }

    public virtual void Reload()
    {
        if (isReloading || currentAmmo == weaponData.magazineSize)
            return;

        isReloading = true;
        reloadStartTime = Time.time;
        reloadProgress = 0f;

        Invoke(nameof(FinishReload), weaponData.reloadTime);
    }

    void FinishReload()
    {
        currentAmmo = weaponData.magazineSize;
        isReloading = false;
        reloadProgress = 1f;
    }


    //Clase hija puede sobreescribir este método para implementar un comportamiento de disparo personalizado
    //Clase hija puede sobreescribir este método para implementar un comportamiento de disparo personalizado
    public virtual void Shoot()
    {
        if (isReloading)
            return;

        if (weaponData == null || weaponData.projectilePrefab == null)
            return;

        if (currentAmmo <= 0)
            return;

        if (Time.time < nextFireTime)
            return;

        nextFireTime = Time.time + weaponData.fireRate;

        currentAmmo--;

        // Generar los proyectiles según la configuración del arma
        for (int i = 0; i < weaponData.projectilesPerShot; i++)
        {
            float spreadX = Random.Range(
                -weaponData.spreadAngle,
                weaponData.spreadAngle
            );

            float spreadY = Random.Range(
                -weaponData.spreadAngle,
                weaponData.spreadAngle
            );

            Quaternion spreadRotation = Quaternion.Euler(
                spreadX,
                spreadY,
                0f
            );

            Vector3 direction = spreadRotation * firePoint.forward;

            GameObject projectile = Instantiate(
                weaponData.projectilePrefab,
                firePoint.position,
                Quaternion.identity
            );

            Projectile projectileScript = projectile.GetComponent<Projectile>();

            if (projectileScript != null)
            {
                projectileScript.SetDirection(direction);
            }
        }
    }

    void Update()
    {
        if (isReloading)
        {
            reloadProgress = Mathf.Clamp01(
                (Time.time - reloadStartTime) / weaponData.reloadTime
            );
        }
    }
}
