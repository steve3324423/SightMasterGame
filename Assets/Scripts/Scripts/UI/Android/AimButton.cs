using System;
using SightMaster.Scripts.Player;
using UnityEngine;

namespace SightMaster.Scripts.UI.Android
{
    public class AimButton : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;

        public event Action<bool> Aimed;

        public bool IsAimed { get; private set; }

        private void OnEnable()
        {
            _playerHealth.Dead += OnDead;
        }

        private void OnDisable()
        {
            _playerHealth.Dead -= OnDead;
        }

        private void OnDead()
        {
            SetIsAimed();
        }

        public void Aim()
        {
            SetIsAimed();
        }

        public void SetIsAimed()
        {
            IsAimed = !IsAimed;
            Aimed?.Invoke(IsAimed);
        }
    }
}
