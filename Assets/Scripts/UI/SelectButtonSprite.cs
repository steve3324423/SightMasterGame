using SightMaster.Scripts.Shop;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(SelectButton))]
    [RequireComponent(typeof(Image))]
    public class SelectButtonSprite : MonoBehaviour
    {
        [SerializeField] private Sprite _defaultSprite;
        [SerializeField] private Sprite _selectedSprite;
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private BuyButton _buyButton;

        private SelectButton _selectButton;
        private Image _image;
        private int _index;

        private void Awake()
        {
            _selectButton = GetComponent<SelectButton>();
            _image = GetComponent<Image>();

            GetDataEvent();
        }

        protected virtual void OnEnable()
        {
            _selectButton.Selected += OnSelected;
            _weaponView.WeaponChanged += OnWeaponChanged;
            _buyButton.Buyed += OnBuyed;
        }

        protected virtual void OnDisable()
        {
            _selectButton.Selected -= OnSelected;
            _weaponView.WeaponChanged -= OnWeaponChanged;
            _buyButton.Buyed -= OnBuyed;
        }

        private void OnBuyed(WeaponToBuy weapon)
        {
            SetSprite(_selectedSprite);
        }

        private void OnSelected(int id)
        {
            _index = id;
            SetSprite(_selectedSprite);
        }

        private void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        private void GetDataEvent()
        {
            _index = YG2.saves.idWeaponSelect;
        }

        private void OnWeaponChanged(WeaponToBuy weapon)
        {
            if (weapon.GetId() == _index)
                SetSprite(_selectedSprite);
            else
                SetSprite(_defaultSprite);
        }
    }
}
