using SightMaster.Scripts.Shop;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class SelectButtonView : ShopButton
    {
        [SerializeField] private BuyButton _buy;

        protected override void OnEnable()
        {
            base.OnEnable();
            _buy.Buyed += OnBuyed;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _buy.Buyed -= OnBuyed;
        }

        protected override void OnWeaponChanged(WeaponToBuy weapon)
        {
            SetViewElements(true, true);
        }

        private void OnBuyed(WeaponToBuy weapon)
        {
            SetViewElements(true, true);
        }
    }
}
