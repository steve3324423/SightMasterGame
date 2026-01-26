using SightMaster.Scripts.Shop;
using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CharacteristicsText : MonoBehaviour
    {
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private CharacteriticsWeapon[] _weapons;
        [SerializeField] private bool _isReloadTime;
        [SerializeField] private bool _isMagazineCapacity;
        [SerializeField] private bool _isDamage;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _weaponView.WeaponChanged += OnWeaponChanged;
        }

        private void OnDisable()
        {
            _weaponView.WeaponChanged += OnWeaponChanged;
        }

        private void OnWeaponChanged(WeaponToBuy weapon)
        {
            foreach (CharacteriticsWeapon weaponCharacteritics in _weapons)
            {
                if (weaponCharacteritics.Id == weapon.GetId())
                {
                    if (_isDamage)
                        _text.text = $"{weaponCharacteritics.GetDamage()}";

                    if (_isReloadTime)
                        _text.text = $"{weaponCharacteritics.GetTimeReload()}";

                    if (_isMagazineCapacity)
                        _text.text = $"{weaponCharacteritics.GetMagazineCapacity()}";
                }
            }
        }
    }
}