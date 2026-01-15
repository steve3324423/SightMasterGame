using System;
using SightMaster.Scripts.Enemy;
using SightMaster.Scripts.LevelHandler;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.InGameCurrency
{
    public class LevelCompleteReward : MonoBehaviour
    {
        [SerializeField] private DeadEnemyCount _deadCount;
        [SerializeField] private LevelEnder _levelEnder;
        [SerializeField] private int _rewardOneEnemy = 225;

        private string _rewardID = "reward";
        private int _rewardValue = 200;

        public event Action ChangeReward;

        public int RewardAmount { get; private set; }

        private void OnEnable()
        {
            YG2.onRewardAdv += OnRewardVideoEvent;
            _deadCount.Deaded += OnDeaded;
            _levelEnder.Wined += OnWined;
        }

        private void OnDisable()
        {
            YG2.onRewardAdv -= OnRewardVideoEvent;
            _deadCount.Deaded -= OnDeaded;
            _levelEnder.Wined -= OnWined;
        }

        private void OnDeaded(int count)
        {
            RewardAmount += _rewardOneEnemy;
        }

        private void OnWined()
        {
            SetMoney(_rewardValue);
        }

        public void SetMoney(int rewardValue)
        {
            SetRewardValue(rewardValue);
            SetRewardAmmont();

            YG2.saves.money += RewardAmount;
            YG2.SaveProgress();
        }

        private void SetRewardValue(int value)
        {
            if (value >= 0)
                _rewardValue = value;
        }

        private void SetRewardAmmont()
        {
            RewardAmount += _rewardValue;
            ChangeReward?.Invoke();
        }

        private void OnRewardVideoEvent(string id)
        {
            if (id == _rewardID)
            {
                YG2.saves.money += _rewardValue;
                SetRewardAmmont();
            }
        }

        public void IncreaseMoney()
        {
            SetRewardValue(_rewardValue);
        }
    }
}
