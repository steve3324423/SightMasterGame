using SightMaster.Scripts.Shop;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(BuyButton))]
    public class ButtonBuyView : ShopButton
    {
        private BuyButton _buyButton;

        protected override void Awake()
        {
            base.Awake();
            _buyButton = GetComponent<BuyButton>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _buyButton.Buyed += OnBuyed;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _buyButton.Buyed -= OnBuyed;
        }

        protected override void OnWeaponChanged(WeaponToBuy weapon)
        {
            foreach (int id in YandexGame.savesData.idWeaponBuy)
            {
                SetViewElements(true, true);

                if (weapon.GetId() == id)
                {
                    SetViewElements(false, false);
                    break;
                }
            }

            Button.interactable = weapon.GetPrice() <= YandexGame.savesData.money;
        }

        private void OnBuyed(WeaponToBuy weapon)
        {
            SetViewElements(false, false);
        }
    }
}
