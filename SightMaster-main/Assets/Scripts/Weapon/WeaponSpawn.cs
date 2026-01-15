using UnityEngine;
using YG;

namespace SightMaster.Scripts.Weapon
{
    public class WeaponSpawn : MonoBehaviour
    {
        [SerializeField] private int _index = 1;

        private int _indexWeaponSave;

        private void Awake()
        {
            GetSavesData();
        }

        private void GetSavesData()
        {
            _indexWeaponSave = YG2.saves.idWeaponSelect;
            gameObject.SetActive(_indexWeaponSave == _index);
        }
    }
}
