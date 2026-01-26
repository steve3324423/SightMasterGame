using SightMaster.Scripts.Shop;
using TMPro;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.UI
{
    public class PriceView : MonoBehaviour
    {
        [SerializeField] private WeaponToBuy _weapon;
        [SerializeField] private BuyButton _buyButton;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            SetPrice();
        }

        private void OnEnable()
        {
            _buyButton.Buyed += OnBuyed;
        }

        private void OnDisable()
        {
            _buyButton.Buyed -= OnBuyed;
        }

        private void OnBuyed(WeaponToBuy weapon)
        {
            if (weapon.GetId() == _weapon.GetId())
                SetText(string.Empty);
        }

        private void SetPrice()
        {
            SetText($"{_weapon.GetPrice()}$");

            foreach (int id in YandexGame.savesData.idWeaponBuy)
            {
                if (_weapon.GetId() == id)
                {
                    SetText(string.Empty);
                    break;
                }
            }
        }

        private void SetText(string text)
        {
            _text.text = text;
        }
    }
}
