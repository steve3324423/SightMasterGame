using System;
using SightMaster.Scripts.Enemy;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.LevelHandler
{
    public class LevelEnder : MonoBehaviour
    {
        [SerializeField] private int _initialEnemyCount;
        [SerializeField] private DeadEnemyCount _deadCount;
        [SerializeField] private int _indexLevel = 1;

        private float _timeForInvoke = 1.3f;

        public event Action Wined;

        private void OnEnable()
        {
            _deadCount.Deaded += OnDead;
        }

        private void OnDisable()
        {
            _deadCount.Deaded -= OnDead;
        }

        private void OnDead(int count)
        {
            if (count == _initialEnemyCount)
                Invoke("WinedInvoke", _timeForInvoke);
        }

        private void WinedInvoke()
        {
            YG2.saves.levels.Add(_indexLevel + 1);
            YG2.SaveProgress();
            Wined?.Invoke();
        }
    }
}
