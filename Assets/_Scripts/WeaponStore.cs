//Shady
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

[System.Serializable]
public class Weapon
{
    public WeaponDataObject WeaponData   = null;
    public GameObject       WeaponObject = null;
}//class end

[HideMonoScript]
public class WeaponStore : MonoBehaviour
{
    [Title("WEAPON UPGRADE", titleAlignment: TitleAlignments.Centered)]
    [DisplayAsString]
    [SerializeField] int _currentWeapon = 0;
    [SerializeField] Weapon[] _weapons = null;

    [Title("UI References")]
    [SerializeField] WeaponStats _weaponStats   = null;
    [SerializeField] Button      _nextButton    = null;
    [SerializeField] Button      _prevButton    = null;
    [SerializeField] Button      _upgradeButton = null;
    [SerializeField] TMP_Text    _upgradeText   = null;

    private void Start()
    {
        for(int i=0 ; i<_weapons.Length ; i++)
        {
            _weapons[i].WeaponData.Init(SaveData.Instance.WeaponLevels[i]);
            _weapons[i].WeaponObject.SetActive(false);
        }//loop end

        _nextButton.onClick.AddListener(()=>ChangeWeapon(1));
        _prevButton.onClick.AddListener(()=>ChangeWeapon(-1));
        _upgradeButton.onClick.AddListener(UpgradeWeapon);

        _currentWeapon = -1;
        ChangeWeapon(1);
    }//Start() end

    private void ChangeWeapon(int num)
    {
        if(_currentWeapon >= 0)
            _weapons[_currentWeapon].WeaponObject.SetActive(false);

        _currentWeapon += num;
        _prevButton.interactable = _currentWeapon == 0 ? false : true;
        _nextButton.interactable = _currentWeapon == _weapons.Length - 1 ? false : true;

        _upgradeButton.interactable = _weapons[_currentWeapon].WeaponData.CanUpgrade;
        _upgradeText.text           = _weapons[_currentWeapon].WeaponData.CanUpgrade ? "UPGRADE" : "MAX";

        _weapons[_currentWeapon].WeaponObject.SetActive(true);
        _weaponStats.Init(_weapons[_currentWeapon].WeaponData);
    }//ChangeWeapon() end

    private void UpgradeWeapon()
    {
        if(_weapons[_currentWeapon].WeaponData.CanUpgrade is false)
            return;
        
        _weapons[_currentWeapon].WeaponData.Upgrade();
        _upgradeButton.interactable = _weapons[_currentWeapon].WeaponData.CanUpgrade;
        _upgradeText.text           = _weapons[_currentWeapon].WeaponData.CanUpgrade ? "UPGRADE" : "MAX";
        _weaponStats.Init(_weapons[_currentWeapon].WeaponData);

        SaveData.Instance.WeaponLevels[_currentWeapon] = _weapons[_currentWeapon].WeaponData.Level;
        SaveSystem.SaveProgress();
    }//UpgradeWeapon() end

}//class end