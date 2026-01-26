using SightMaster.Scripts.LevelHandler;
using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TimeGameView : MonoBehaviour
    {
        [SerializeField] private GameplayTime _time;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            float minutes = Mathf.FloorToInt(_time.TimeGame / 60);
            float seconds = Mathf.FloorToInt(_time.TimeGame % 60);

            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            _text.text = timeString;
        }
    }
}
