using UnityEngine;
using YG;

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
