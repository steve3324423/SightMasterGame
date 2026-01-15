using SightMaster.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(RawImage))]
    public class BloodImage : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _health;

        private float _damageScale = 10f;
        private float _maxHealth = 100f;
        private float _defaultValue = 0;
        private Color _colorImage;
        private RawImage _image;

        private void Awake()
        {
            _image = GetComponent<RawImage>();
            _colorImage = _image.color;
        }

        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void SetColorAlpha(float value)
        {
            _colorImage.a = value;
            _colorImage.a = Mathf.Clamp01(_colorImage.a);
            _image.color = _colorImage;
        }

        private void OnHealthChanged(int health)
        {
            if (health < _maxHealth)
                SetColorAlpha((float)health / _damageScale);
            else
                SetColorAlpha(_defaultValue);
        }
    }
}
