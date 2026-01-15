using System;
using SightMaster.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SightMaster.Scripts.HandlerPause
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private SettingPanelHandler _settingPauseHandler;

        private bool _isSettingActive;

        public event Action<bool> Paused;

        private void OnEnable()
        {
            SetTimeScale(1);
            SceneManager.sceneLoaded += OnSceneLoaded;
            _settingPauseHandler.Toggled += OnToggled;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            _settingPauseHandler.Toggled -= OnToggled;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SetTimeScale(1);
        }

        private void Update()
        {
            if (_isSettingActive == false && Input.GetKeyDown(KeyCode.Escape))
                Pause();
        }

        private void OnToggled(bool isActivated)
        {
            _isSettingActive = isActivated;
            SetTimeScale(Time.timeScale == 0 ? 1 : 0);
        }

        private void SetTimeScale(float time)
        {
            Time.timeScale = time;
        }

        public void Pause()
        {
            SetTimeScale(Time.timeScale == 0 ? 1 : 0);
            Paused?.Invoke(Time.timeScale == 0);
        }
    }
}
