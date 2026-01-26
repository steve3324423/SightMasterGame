using UnityEngine;
using YG;

namespace SightMaster.Scripts.Shop
{
    public class PanelPrice : MonoBehaviour
    {
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private int _index = 1;

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
            if (weapon.GetId() == _index)
                Destroy(gameObject);
        }

        private void OnWeaponChanged(WeaponToBuy weapon)
        {
            foreach (int id in YandexGame.savesData.idWeaponBuy)
            {
                if (id == _index)
                    Destroy(gameObject);
            }
        }
    }
}
