using SightMaster.Scripts.Player;
using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HealthBarPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _health;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int value)
        {
            _text.text = value.ToString();
        }
    }
}
