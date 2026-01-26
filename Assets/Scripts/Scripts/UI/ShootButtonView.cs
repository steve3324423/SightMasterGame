using SightMaster.Scripts.UI.Android;
using UnityEngine;
using UnityEngine.UI;

namespace SightMaster.Scripts.UI
{
    public class ShootButtonView : MonoBehaviour
    {
        [SerializeField] private AimButton _aim;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.enabled = false;
        }

        private void OnEnable()
        {
            _aim.Aimed += OnAimed;
        }

        private void OnDisable()
        {
            _aim.Aimed -= OnAimed;
        }

        private void OnAimed(bool isAimed)
        {
            _image.enabled = isAimed;
        }
    }
}
