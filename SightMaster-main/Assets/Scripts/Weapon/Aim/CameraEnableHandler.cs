using SightMaster.Scripts.Camera;
using SightMaster.Scripts.LevelHandler;
using UnityEngine;

namespace SightMaster.Scripts.Weapon.Aim
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public abstract class CameraEnableHandler : MonoBehaviour
    {
        [SerializeField] private CameraFollowBullet _cameraFollowBullet;
        [SerializeField] private LevelEnder _levelEnder;
        [SerializeField] private Aim _aim;

        protected bool IsFollowed;

        protected UnityEngine.Camera Camera;

        private void Awake()
        {
            Camera = GetComponent<UnityEngine.Camera>();
        }

        private void OnEnable()
        {
            _cameraFollowBullet.Followed += OnFollowed;
            _levelEnder.Wined += OnWined;
            _aim.Aimed += OnAimed;
        }

        private void OnDisable()
        {
            _cameraFollowBullet.Followed -= OnFollowed;
            _levelEnder.Wined -= OnWined;
            _aim.Aimed -= OnAimed;
        }

        protected abstract void OnWined();

        protected abstract void OnAimed(bool isAimed);

        protected abstract void OnFollowed(bool isFollowed);
    }
}
