using SightMaster.Scripts.Shop;
using TMPro;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BuyTextView : MonoBehaviour
    {
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private BuyButton _buyButton;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _weaponView.WeaponChanged += OnWeaponChanged;
            _buyButton.Buyed += OnBuyed;
        }

        private void OnDisable()
        {
            _weaponView.WeaponChanged -= OnWeaponChanged;
            _buyButton.Buyed += OnBuyed;
        }

        private void OnBuyed(WeaponToBuy weapon)
        {
            _text.enabled = false;
        }

        private void OnWeaponChanged(WeaponToBuy weapon)
        {
            _text.enabled = true;

            foreach (int id in YandexGame.savesData.idWeaponBuy)
            {
                if (id == weapon.GetId())
                    _text.enabled = false;
            }
        }
    }
}