//Shady
using TMPro;
using UnityEngine;
using Unity.FPS.Game;
using Sirenix.OdinInspector;

[HideMonoScript]
public class WeaponStats : MonoBehaviour
{
    [Title("WEAPON STATS", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] TMP_Text _weaponNameText     = null;
    [SerializeField] TMP_Text _levelText          = null;
    [SerializeField] TMP_Text _bulletsPerShotText = null;
    [SerializeField] TMP_Text _clipSizeText       = null;
    [SerializeField] TMP_Text _maxAmmoText        = null;
    [SerializeField] TMP_Text _damageText         = null;

    public void Init(WeaponController weapon)
    {
        _weaponNameText.text     = weapon.WeaponName.ToUpper();
        _levelText.text          = $"Level : {weapon.WeaponData.Level}";
        _bulletsPerShotText.text = $"Bullets Per Shot : {weapon.WeaponData.Data.BulletsPerShot}";
        _clipSizeText.text       = $"Clip Size : {weapon.WeaponData.Data.ClipSize}";
        _maxAmmoText.text        = $"Max Ammo : {weapon.WeaponData.Data.MaxAmmo}";
        _damageText.text         = $"Damage : {weapon.WeaponData.Data.Damage}";
        gameObject.SetActive(true);
    }//Init() end
}//class end