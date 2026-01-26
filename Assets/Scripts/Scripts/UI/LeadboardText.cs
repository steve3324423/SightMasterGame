using UnityEngine;
using YG.LanguageLegacy;

namespace SightMaster.Scripts.UI
{
    public class LeadboardText : MonoBehaviour
    {
        [SerializeField] private LanguageYG _languageLeadboardText;
        [SerializeField] private LanguageYG _languageBackText;

        private LeaderboardButton _leardboardButton;

        private void Awake()
        {
            _leardboardButton = transform.parent.GetComponent<LeaderboardButton>();
        }

        private void OnEnable()
        {
            _leardboardButton.Clicked += OnClicked;
        }

        private void OnDestroy()
        {
            _leardboardButton.Clicked -= OnClicked;
        }

        private void OnClicked(bool isEnabled)
        {
            _languageBackText.enabled = isEnabled;
            _languageLeadboardText.enabled = !isEnabled;
        }
    }
}
