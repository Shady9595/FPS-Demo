//Shady
using System;
using UnityEngine;
using Sirenix.OdinInspector;

    [Serializable]
    public sealed class WeaponData
    {
        // Fields
        [SerializeField] int   _bulletsPerShot = 1;
        [SerializeField] int   _clipSize       = 30;
        [SerializeField] int   _maxAmmo        = 8;
        [SerializeField] float _damage         = 5f;

        // Properties
        public int   BulletsPerShot => _bulletsPerShot;
        public int   ClipSize       => _clipSize;
        public int   MaxAmmo        => _maxAmmo;
        public float Damage         => _damage;

        public WeaponData()
        {
            _bulletsPerShot = 1;
            _clipSize       = 30;
            _maxAmmo        = 8;
            _damage         = 5f;
        }//Constructor() end

    }//class end

    [HideMonoScript]
    [CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObjects/Weapon Data", order = 1)]
    public class WeaponDataObject : ScriptableObject
    {
        [SerializeField] string _weaponName = "Weapon";
        [SerializeField] int _level = 1;
        [Space]
        [SerializeField] WeaponData[] _upgrades = new WeaponData[1];

        // Properties
        public string WeaponName => _weaponName;
        public int Level => _level;
        public WeaponData Data => _upgrades[_level-1];
        public bool CanUpgrade => _level < _upgrades.Length;

        // Methods
        public void Init(int level) => _level = level;

        public void Upgrade() => _level++;

    }//class end

