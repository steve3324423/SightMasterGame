using Unity.VisualScripting;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _height = 4.5f;
    [SerializeField] private float _rearDistance = 7f;
    [SerializeField] private float _positionFollowSpeed = 3f;
    [SerializeField] private float _rotationFollowSpeed = 7f;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private Transform _lookTargetOverride;

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
        transform.rotation = _lookTargetOverride.rotation;
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
        if(_canRotate)
        {
            Vector3 localOffset = new Vector3(0, _height, -_rearDistance);
            Vector3 desiredPosition = _target.position + _target.rotation * localOffset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, _positionFollowSpeed * Time.deltaTime);

            Quaternion targetRotation = _lookTargetOverride.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationFollowSpeed * Time.deltaTime);
        }
    }
}