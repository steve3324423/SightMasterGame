using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class FirstAidKitTextSpawner : MonoBehaviour
    {
        [SerializeField] private FirstAidKit.FirstAidKit[] _firstAidKits;

        private TextMeshProUGUI _text;
        private float _timeForInvoke = 5f;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.enabled = false;
        }

        private void OnEnable()
        {
            foreach (FirstAidKit.FirstAidKit firstAidKit in _firstAidKits)
                firstAidKit.Spawned += OnSpawned;
        }

        private void OnDisable()
        {
            foreach (FirstAidKit.FirstAidKit firstAidKit in _firstAidKits)
                firstAidKit.Spawned -= OnSpawned;
        }

        private void OnSpawned()
        {
            _text.enabled = true;
            Invoke("DisabledText", _timeForInvoke);
        }

        private void DisabledText()
        {
            _text.enabled = false;
        }
    }
}
