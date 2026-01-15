using SightMaster.Scripts.Player;
using SightMaster.Scripts.LevelHandler;
using UnityEngine;

namespace SightMaster.Scripts.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _height = 4.5f;
        [SerializeField] private float _rearDistance = 7f;
        [SerializeField] private float _positionFollowSpeed = 3f;
        [SerializeField] private float _rotationFollowSpeed = 7f;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private LevelEnder _levelEnder;

        private bool _canRotate = true;

        private void OnEnable()
        {
            _levelEnder.Wined += OnWined;
            _playerHealth.Dead += OnDead;
        }

        private void Start()
        {
            Vector3 localOffset = new Vector3(0, _height, -_rearDistance);
            Vector3 initialDesiredPosition = _target.position + _target.rotation * localOffset;

            transform.position = initialDesiredPosition;
        }

        private void OnDisable()
        {
            _levelEnder.Wined -= OnWined;
            _playerHealth.Dead -= OnDead;
        }

        private void OnWined()
        {
            _canRotate = false;
        }

        private void OnDead()
        {
            _canRotate = false;
        }

        private void LateUpdate()
        {
            if (_canRotate)
            {
                Vector3 localOffset = new Vector3(0, _height, -_rearDistance);
                Vector3 desiredPosition = _target.position + _target.rotation * localOffset;
            }
        }
    }
}