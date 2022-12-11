//Shady
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

    private void Start()
    {
        for(int i=0 ; i<_weapons.Length ; i++)
        {
            _weapons[i].WeaponData.Init(SaveData.Instance.WeaponLevels[i]);
            _weapons[i].WeaponObject.SetActive(false);
        }//loop end
    }//Start() end

}//class end