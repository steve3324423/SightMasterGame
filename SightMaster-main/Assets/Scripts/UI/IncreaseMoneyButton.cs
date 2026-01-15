using SightMaster.Scripts.InGameCurrency;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.UI
{
    public class IncreaseMoneyButton : MonoBehaviour
    {
        [SerializeField] private LevelCompleteReward _reward;

        private string _rewardID = "reward";

        public void Double()
        {
            YG2.RewardedAdvShow(_rewardID);
            _reward.IncreaseMoney();
            transform.gameObject.SetActive(false);
        }
    }
}
