//Shady
using UnityEngine;
using Sirenix.OdinInspector;

[HideMonoScript]
public class GameInit : MonoBehaviour
{
    [Title("GAME INIT", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] WeaponDataObject[] _weapons = null;

    private void Awake()
    {    
        // Making SaveData for the first time to save weapon Levels
        if(SaveData.Instance.WeaponLevels is null || SaveData.Instance.WeaponLevels.Count == 0)
        {
            foreach(WeaponDataObject weaponData in _weapons)
                SaveData.Instance.WeaponLevels.Add(weaponData.Level);
            SaveSystem.SaveProgress();
        }//if end
        // Getting data from Save data
        else
        {
            for(int i=0 ; i<_weapons.Length ; i++)
                _weapons[i].Init(SaveData.Instance.WeaponLevels[i]);
        }//else end
    }//Awake() end

}//class end