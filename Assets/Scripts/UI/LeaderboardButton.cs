using System;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class LeaderboardButton : MonoBehaviour
    {
        [SerializeField] private GameObject _leaderboardPanel;

        private bool _enabled;

        public event Action<bool> Clicked;

        public void Touched()
        {
            _enabled = !_enabled;
            _leaderboardPanel.SetActive(_enabled);
            Clicked?.Invoke(_enabled);
        }
    }
}
