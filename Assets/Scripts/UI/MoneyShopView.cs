using SightMaster.Scripts.Shop;
using TMPro;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MoneyShopView : MonoBehaviour
    {
        [SerializeField] private BuyButton _buyButton;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = $"{YG2.saves.money}";
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
            _text.text = $"{YG2.saves.money}";
        }
    }
}
