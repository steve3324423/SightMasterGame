using System;
using SightMaster.Scripts.UI.Android;
using UnityEngine;
using UnityEngine.UI;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(Slider))]
    public class SliderZoom : MonoBehaviour
    {
        [SerializeField] private AimButton _aimButton;

        private Slider _slider;
        private float _minValue = 8f;
        private float _maxValue = 30f;

        public event Action<float> ValueChanged;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.minValue = _minValue;
            _slider.maxValue = _maxValue;
        }

        private void OnEnable()
        {
            _aimButton.Aimed += OnAimed;
            gameObject.SetActive(_aimButton.IsAimed);
        }

        private void OnDestroy()
        {
            _aimButton.Aimed -= OnAimed;
        }

        private void OnAimed(bool isAimed)
        {
            gameObject.SetActive(isAimed);
        }

        public void ChangeValue()
        {
            ValueChanged?.Invoke(_slider.value);
        }
    }
}
