using SightMaster.Scripts.Weapon;
using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private AmmoHandler[] _weaponAmmo;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            foreach (AmmoHandler weapon in _weaponAmmo)
                weapon.BulletChanged += OnBulletChanged;
        }

        private void OnDisable()
        {
            foreach (AmmoHandler weapon in _weaponAmmo)
                weapon.BulletChanged -= OnBulletChanged;
        }

        private void OnBulletChanged(int currentAmmo, int ammoInReserve)
        {
            _text.text = $"{currentAmmo}/{ammoInReserve}";
        }
    }
}
