using SightMaster.Scripts.Enemy;
using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DeadEnemyCountView : MonoBehaviour
    {
        [SerializeField] private DeadEnemyCount _enemyCount;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _text.text = _enemyCount.Count.ToString();
        }
    }
}