using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public WeaponController weaponController;
    public TextMeshProUGUI ammoText;
    public Image reloadFill;
    public GameObject reloadBar;
    public TextMeshProUGUI weaponNameText;

    void Update()
    {
        if (weaponController == null || ammoText == null)
            return;

        WeaponBase weapon = weaponController.currentWeapon;

        if (weapon == null)
            return;

        reloadBar.SetActive(weapon.isReloading);

        if (weapon.isReloading)
        {
            ammoText.text = "RECARGANDO...";
            reloadFill.fillAmount = weapon.reloadProgress;
        }
        else
        {
            ammoText.text = weapon.currentAmmo + " / " + weapon.weaponData.magazineSize;
            weaponNameText.text = weapon.weaponData.weaponName;
        }
    }
}