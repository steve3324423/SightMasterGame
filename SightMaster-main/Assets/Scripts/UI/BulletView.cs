using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BulletView : MonoBehaviour
{
    [SerializeField] private WeaponAmmo[] _weaponAmmo;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        foreach (WeaponAmmo weapon in _weaponAmmo)
            weapon.BulletChanged += OnBulletChanged;
    }

    private void OnDisable()
    {
        foreach (WeaponAmmo weapon in _weaponAmmo)
            weapon.BulletChanged -= OnBulletChanged;
    }

    private void OnBulletChanged(int currentAmmo,int ammoInReserve)
    {
        _text.text = $"{currentAmmo}/{ammoInReserve}";
    }
}
