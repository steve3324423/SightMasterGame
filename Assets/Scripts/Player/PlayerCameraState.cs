using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public class PlayerCameraState : FSMState
    {
        private readonly bool _isFollowerEnabled;
        private readonly bool _isAimEnabled;
        private readonly Camera _cameraFollower;
        private readonly Camera _cameraAim;

        public PlayerCameraState(StateMachine stateMachine, bool isFollowerEnabled, bool isAimEnabled, Camera cameraFollower, Camera cameraAim)
            : base(stateMachine)
        {
            _isFollowerEnabled = isFollowerEnabled;
            _isAimEnabled = isAimEnabled;
            _cameraFollower = cameraFollower;
            _cameraAim = cameraAim;
        }

        public override void Enter()
        {
            _cameraFollower.enabled = _isFollowerEnabled;
            _cameraAim.enabled = _isAimEnabled;
        }
    }
}
