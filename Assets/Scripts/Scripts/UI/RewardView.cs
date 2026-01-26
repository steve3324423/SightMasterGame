using SightMaster.Scripts.InGameCurrency;
using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class RewardView : MonoBehaviour
    {
        [SerializeField] private LevelCompleteReward _reward;

        private float _timeForInvoke = 1f;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _text.text = $"{_reward.RewardAmount}$";
            _reward.ChangeReward += OnChangeReward;
        }

        private void OnDisable()
        {
            _reward.ChangeReward -= OnChangeReward;
        }

        private void OnChangeReward()
        {
            _text.text = $"{_reward.RewardAmount}$";
        }
    }
}
