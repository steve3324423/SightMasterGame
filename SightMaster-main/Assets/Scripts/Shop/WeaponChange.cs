using System;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] private WeaponToBuy _weaponToBuy;

    public void Selected()
    {
        int index = _weaponToBuy.GetId() - 1;
        IndexChanged?.Invoke(index);
    }

    public event Action<int> IndexChanged;
}
