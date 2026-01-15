using SightMaster.Scripts.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public abstract class ShopButton : MonoBehaviour
    {
        [SerializeField] private WeaponView _weaponView;

        protected Button Button;
        private Image _image;

        protected virtual void Awake()
        {
            _image = GetComponent<Image>();
            Button = GetComponent<Button>();
        }

        protected virtual void OnEnable()
        {
            _weaponView.WeaponChanged += OnWeaponChanged;
        }

        protected virtual void OnDisable()
        {
            _weaponView.WeaponChanged -= OnWeaponChanged;
        }

        protected virtual void OnWeaponChanged(WeaponToBuy weapon)
        {
            SetViewElements(false, false);
        }

        protected void SetViewElements(bool isButtonEnabled, bool isImageEnabled)
        {
            Button.enabled = isButtonEnabled;
            _image.enabled = isImageEnabled;
        }
    }
}
