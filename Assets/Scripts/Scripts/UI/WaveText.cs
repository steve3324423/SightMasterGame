using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class WaveText : MonoBehaviour
    {
        private WaveTimerText _timerText;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _timerText = transform.parent.GetComponent<WaveTimerText>();
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _timerText.EnabledText += OnEnabledText;
        }

        private void OnDisable()
        {
            _timerText.EnabledText -= OnEnabledText;
        }

        private void OnEnabledText(bool isEnabled)
        {
            _text.enabled = isEnabled;
        }
    }
}
