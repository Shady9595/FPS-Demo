//Shady
using System.Collections.Generic;

public class SaveData
{
    private static SaveData _instance = null;
    public static SaveData Instance
    {
        get
        {
            if(_instance is null)
            {
                _instance = new SaveData();
                SaveSystem.LoadProgress();
            }//if end
            return _instance;
        }//get end
    }//Property end

    public void Reset() => _instance = new SaveData();

    public List<int> WeaponLevels = new List<int>();

    public string HashOfSaveData;

    private SaveData(){}

    private SaveData(List<int> weaponLevels)
    {
        WeaponLevels = weaponLevels;
    }//SaveData() end

    public SaveData CreateSaveObject() => new SaveData(Instance.WeaponLevels);

}//class end