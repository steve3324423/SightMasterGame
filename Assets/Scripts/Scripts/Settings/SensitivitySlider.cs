using UnityEngine;
using UnityEngine.UI;
using YG;

namespace SightMaster.Scripts.Setting
{
    public class SensitivitySlider : MonoBehaviour
    {
        [SerializeField] private float _mobileValue = 15f;
        [SerializeField] private float _maxValue = 5f;

        private bool _isMobile = Application.isMobilePlatform;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            _slider.maxValue = _isMobile ? _maxValue * _mobileValue : _maxValue;
            _slider.value = _isMobile ? YG2.saves.sensitivity * _mobileValue : YG2.saves.sensitivity;
        }

        public void ChangeValue()
        {
            if (_isMobile)
            {
                float factor = Mathf.Approximately(_mobileValue, 0f) ? 1f : _mobileValue;
                YG2.saves.sensitivity = Mathf.Clamp(_slider.value / factor, 0f, _maxValue);
            }
            else
            {
                YG2.saves.sensitivity = Mathf.Clamp(_slider.value, 0f, _maxValue);
            }
        }
    }
}
