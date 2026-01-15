using UnityEngine;
using UnityEngine.UI;

namespace SightMaster.Scripts.Shop
{
    public class BorderSelectWeapon : MonoBehaviour
    {
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private int _index = 1;

        private Color _colorImage;
        private RawImage _image;

        private void Awake()
        {
            _image = GetComponent<RawImage>();
            _colorImage = _image.color;
        }

        private void OnEnable()
        {
            _weaponView.WeaponChanged += OnWeaponChanged;
            _buyButton.Buyed += OnBuyed;
        }

        private void OnDisable()
        {
            _weaponView.WeaponChanged -= OnWeaponChanged;
            _buyButton.Buyed -= OnBuyed;
        }

        private void OnWeaponChanged(WeaponToBuy weapon)
        {
            if (weapon.GetId() == _index)
                SetTransparency(1);
            else
                SetTransparency(0);
        }

        private void OnBuyed(WeaponToBuy weapon)
        {
            if (weapon.GetId() == _index)
                OnWeaponChanged(weapon);
        }

        private void SetTransparency(float value)
        {
            _colorImage.a = value;
            _image.color = _colorImage;
        }
    }
}
