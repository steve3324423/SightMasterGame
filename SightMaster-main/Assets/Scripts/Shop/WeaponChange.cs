using System;
using UnityEngine;

namespace SightMaster.Scripts.Shop
{
    public class WeaponChange : MonoBehaviour
    {
        [SerializeField] private WeaponToBuy _weaponToBuy;

        public event Action<int> IndexChanged;

        public void Selected()
        {
            int index = _weaponToBuy.GetId() - 1;
            IndexChanged?.Invoke(index);
        }
    }
}
