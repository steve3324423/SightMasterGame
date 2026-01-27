using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.LevelHandler;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Weapon.AimHandler
{
    [RequireComponent(typeof(Camera))]
    public abstract class CameraEnableHandler : MonoBehaviour
    {
        [SerializeField] private CameraFollowBullet _cameraFollowBullet;
        [SerializeField] private LevelEnder _levelEnder;

        private IInputWeapon _inputWeapon;
        protected bool IsFollowed;
        protected Camera Camera;

        [Inject]
        public void Construct(IInputWeapon inputWeapon)
        {
            _inputWeapon = inputWeapon;
            _inputWeapon.Aiming += OnAimed;
        }

        private void Awake()
        {
            Camera = GetComponent<Camera>();
        }

        private void OnEnable()
        {
            _cameraFollowBullet.Followed += OnFollowed;
            _levelEnder.Wined += OnWined;
        }

        private void OnDisable()
        {
            _cameraFollowBullet.Followed -= OnFollowed;
            _levelEnder.Wined -= OnWined;
        }

        protected abstract void OnWined();

        protected abstract void OnAimed(bool isAimed);

        protected abstract void OnFollowed(bool isFollowed);
    }
}
