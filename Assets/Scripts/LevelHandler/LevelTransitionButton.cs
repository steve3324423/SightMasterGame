using UnityEngine;
using UnityEngine.UI;
using YG;

namespace SightMaster.Scripts.LevelHandler
{
    [RequireComponent(typeof(Button))]
    public class LevelTransitionButton : MonoBehaviour
    {
        [SerializeField] private int _levelNumber = 1;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            GetSaveData();
        }

        private void GetSaveData()
        {
            foreach (int i in YG2.saves.levels)
            {
                if (i == _levelNumber)
                    _button.interactable = true;
            }
        }
    }
}