using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Aim _aim;
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private Transform _cameraLookTarget;
    [SerializeField] private float _playerRotationSpeed = 10f;

    private PlayerHealth _playerHealth;
    private bool _canRotate = true;
    private bool _isAimed;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _aim.Aimed += OnAimed;
        _pauseHandler.Paused += OnPaused;
        _playerHealth.Dead += OnDead;
        _levelEnder.Wined += OnWined;
    }

    private void OnDisable()
    {
        _aim.Aimed -= OnAimed;
        _pauseHandler.Paused -= OnPaused;
        _playerHealth.Dead -= OnDead;
        _levelEnder.Wined -= OnWined;
    }

    private void OnPaused(bool isPaused)
    {
        _canRotate = !isPaused;
    }

    private void OnAimed(bool isAimed)
    {
        _isAimed = isAimed;
    }

    private void OnWined()
    {
        _canRotate = false;
    }

    private void OnDead()
    {
        _canRotate = false;
    }

    private void Update()
    {
        if (_canRotate && _isAimed == false)
        {
            Quaternion targetPlayerRotation = Quaternion.Euler(0f, _cameraLookTarget.rotation.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetPlayerRotation, _playerRotationSpeed * Time.deltaTime);
        }
    }
}