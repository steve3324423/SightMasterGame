using UnityEngine;

[RequireComponent(typeof(Camera))]
public abstract class CameraEnableHandler : MonoBehaviour
{
    [SerializeField] private CameraFollowBullet _cameraFollowBullet;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private Aim _aim;

    protected bool IsFollowed;

    protected Camera Camera;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
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
