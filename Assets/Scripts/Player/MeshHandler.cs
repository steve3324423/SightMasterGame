using SightMaster.Scripts.Weapon;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Player
{
    public abstract class MeshHandler : MonoBehaviour
    {
        private IInputWeapon _inputWeapon;

        [Inject]
        public void Construct(IInputWeapon inputWeapon)
        {
            _inputWeapon = inputWeapon;
        }

        private void OnEnable()
        {
            _inputWeapon.Aiming += OnAimed;
        }

        private void OnDisable()
        {
            _inputWeapon.Aiming -= OnAimed;
        }

        protected abstract void OnAimed(bool isAimed);
    }
}
