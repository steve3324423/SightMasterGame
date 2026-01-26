using System;
using SightMaster.Scripts.HandlerPause;
using SightMaster.Scripts.LevelHandler;
using SightMaster.Scripts.Player;
using UnityEngine;

namespace SightMaster.Scripts.Weapon
{
    public class DekstopWeapon : IInputWeapon
    {
        private bool _isCanGetValue = true;
        private DekstopInputHandler _dekstopHandler;
        private PauseHandler _pauseHandler;
        private PlayerHealth _playerHealth;
        private LevelEnder _levelEnder;

        public event Action<bool> Shooting;
        public event Action<bool> Aiming;

        public DekstopWeapon(LevelEnder levelEnder, PlayerHealth playerHealth, PauseHandler pauseHandler, DekstopInputHandler dekstopHandler)
        {
            _levelEnder = levelEnder;
            _playerHealth = playerHealth;
            _pauseHandler = pauseHandler;
            _dekstopHandler = dekstopHandler;

            _dekstopHandler.Shooting += OnShooting;
            _dekstopHandler.Aiming += OnAiming;
            _pauseHandler.Paused += OnPaused;
            _levelEnder.Wined += OnWined;
            _playerHealth.Dead += OnDead;
        }

        private void OnShooting(bool isShooting)
        {
            Shooting?.Invoke(_isCanGetValue ? isShooting : false);
        }

        private void OnAiming(bool isAiming)
        {
            Aiming?.Invoke(_isCanGetValue ? isAiming : false);
        }

        private void OnWined()
        {
            _isCanGetValue = false;
        }

        private void OnDead()
        {
            _isCanGetValue = false;
        }

        private void OnPaused(bool isPaused)
        {
            _isCanGetValue = !isPaused;
        }
    }
}