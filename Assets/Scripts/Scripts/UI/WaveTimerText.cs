using System;
using System.Collections;
using System.Collections.Generic;
using SightMaster.Scripts.Enemy;
using SightMaster.Scripts.Player;
using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class WaveTimerText : MonoBehaviour
    {
        [SerializeField] private WaveSpawned[] _waveSpawned;
        [SerializeField] private PlayerHealth _playerHealth;

        private WaitForSeconds _waitSeconds;
        private float _timeForCoroutine = 1f;
        private TextMeshProUGUI _text;

        public event Action<bool> EnabledText;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();

            _waitSeconds = new WaitForSeconds(_timeForCoroutine);
            EnableText(false);
        }

        private void OnEnable()
        {
            foreach (WaveSpawned enemySpawned in _waveSpawned)
                enemySpawned.WarningBeforeSpawned += OnWarningBeforeSpawned;

            _playerHealth.Dead += OnDead;
        }

        private void OnDisable()
        {
            foreach (WaveSpawned enemySpawned in _waveSpawned)
                enemySpawned.WarningBeforeSpawned -= OnWarningBeforeSpawned;

            _playerHealth.Dead -= OnDead;
        }

        private void OnWarningBeforeSpawned(List<GameObject> childs)
        {
            StartCoroutine(SetText());
        }

        private IEnumerator SetText()
        {
            float timeValue = 4f;
            EnableText(true);

            while (timeValue > 1)
            {
                timeValue--;
                _text.text = timeValue.ToString();

                yield return _waitSeconds;
            }

            EnableText(false);
        }

        private void EnableText(bool isEnabled)
        {
            _text.enabled = isEnabled;
            EnabledText?.Invoke(isEnabled);
        }

        private void OnDead()
        {
            EnableText(false);
        }
    }
}
