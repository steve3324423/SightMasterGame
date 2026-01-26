using SightMaster.Scripts.Weapon.AimHandler;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public abstract class MeshHandler : MonoBehaviour
    {
        [SerializeField] private Aim _aim;

        private void OnEnable()
        {
            _aim.Aimed += OnAimed;
        }

        private void OnDisable()
        {
            _aim.Aimed -= OnAimed;
        }

        protected abstract void OnAimed(bool isAimed);
    }
}
