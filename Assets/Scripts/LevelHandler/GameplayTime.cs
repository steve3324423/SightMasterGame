using SightMaster.Scripts.Player;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.LevelHandler
{
    public class GameplayTime : MonoBehaviour
    {
        private const string NameLeaderboard = "Leadboard";

        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private LevelEnder _levelEnder;

        private bool _isGameStopped;

        public float TimeGame { get; private set; } = 0;

        private void OnEnable()
        {
            _levelEnder.Wined += OnWined;
            _playerHealth.Dead += OnDead;
        }

        private void OnDisable()
        {
            _levelEnder.Wined -= OnWined;
            _playerHealth.Dead -= OnDead;
        }

        private void Update()
        {
            if (_isGameStopped == false)
                TimeGame += Time.deltaTime;
        }

        private void OnWined()
        {
            _isGameStopped = true;
            YandexGame.savesData.TimeLevel = TimeGame;
            YandexGame.NewLBScoreTimeConvert(NameLeaderboard, YandexGame.savesData.TimeLevel + TimeGame);
        }

        private void OnDead()
        {
            _isGameStopped = false;
        }
    }
}
