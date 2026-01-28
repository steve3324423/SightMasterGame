using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.FSM;
using SightMaster.Scripts.LevelHandler;
using SightMaster.Scripts.Weapon;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Player
{
    public class PlayerCameraStateHandler : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _player;
        [SerializeField] private LevelEnder _levelEnder;
        [SerializeField] private CameraFollowBullet _cameraFollowBullet;
        [SerializeField] private Camera _cameraFollower;
        [SerializeField] private Camera _cameraAim;

        private StateMachine _stateMachine;
        private PlayerCameraState _followingState;
        private PlayerCameraState _aimingState;
        private PlayerCameraState _bulletFollowState;
        private PlayerCameraState _deadState;
        private IInputWeapon _inputWeapon;
        private bool _isFollowed;

        [Inject]
        public void Construct(IInputWeapon inputWeapon)
        {
            _inputWeapon = inputWeapon;
            _inputWeapon.Aiming += OnAimed;
        }

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _followingState = new PlayerCameraState(_stateMachine, isFollowerEnabled: true, isAimEnabled: false, cameraFollower: _cameraFollower, cameraAim: _cameraAim);
            _aimingState = new PlayerCameraState(_stateMachine, isFollowerEnabled: false, isAimEnabled: true, cameraFollower: _cameraFollower, cameraAim: _cameraAim);
            _bulletFollowState = new PlayerCameraState(_stateMachine, isFollowerEnabled: true, isAimEnabled: false, cameraFollower: _cameraFollower, cameraAim: _cameraAim);
            _deadState = new PlayerCameraState(stateMachine: _stateMachine, isFollowerEnabled: true, isAimEnabled: false, cameraFollower: _cameraFollower, cameraAim: _cameraAim);

            _stateMachine.AddState(PlayerCameraStateNames.Following, _followingState);
            _stateMachine.AddState(PlayerCameraStateNames.Aiming, _aimingState);
            _stateMachine.AddState(PlayerCameraStateNames.BulletFollow, _bulletFollowState);
            _stateMachine.AddState(PlayerCameraStateNames.Dead, _deadState);

            SetState(PlayerCameraStateNames.Following);
        }

        private void OnEnable()
        {
            _player.Dead += OnDead;
            _levelEnder.Wined += OnWined;
            _cameraFollowBullet.Followed += OnFollowed;
        }

        private void OnDisable()
        {
            _player.Dead -= OnDead;
            _levelEnder.Wined -= OnWined;
            _cameraFollowBullet.Followed -= OnFollowed;
            _inputWeapon.Aiming -= OnAimed;
        }

        private void OnDead()
        {
            SetState(PlayerCameraStateNames.Dead);
        }

        private void OnWined()
        {
            SetState(PlayerCameraStateNames.Following);
        }

        private void OnFollowed(bool isFollowed)
        {
            _isFollowed = isFollowed;

            if (isFollowed)
                SetState(PlayerCameraStateNames.BulletFollow);
            else
                SetState(PlayerCameraStateNames.Following);
        }

        private void OnAimed(bool isAimed)
        {
            if (_isFollowed) 
                return;

            if (isAimed)
                SetState(PlayerCameraStateNames.Aiming);
            else
                SetState(PlayerCameraStateNames.Following);
        }

        private void SetState(string nameState)
        {
            _stateMachine.SetState(nameState);
        }
    }
}