using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class SpriteAimGet : MonoBehaviour
{
    [SerializeField] private CameraFollowBullet _cameraFollowBullet;
    [SerializeField] private SpriteGet[] _spriteGet;
    [SerializeField] private Aim _aim;

    private bool _isFollowed;
    private Texture _texture;
    private RawImage _rawImage;

    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }

    private void Start()
    {
        SetTexture();
    }

    private void OnEnable()
    {
        _cameraFollowBullet.Followed += OnFollowed;
        _aim.Aimed += OnAimed;
    }

    private void OnDisable()
    {
        _cameraFollowBullet.Followed -= OnFollowed;
        _aim.Aimed -= OnAimed;
    }

    private void SetTexture()
    {
        foreach (SpriteGet sprite in _spriteGet)
        {
            if (sprite.gameObject.activeSelf)
                _texture = sprite.GetTexture();
        }

        _rawImage.texture = _texture;
    }

    private void OnFollowed(bool isFollowed)
    {
        _rawImage.enabled = !isFollowed;
        _isFollowed = isFollowed;
    }

    private void OnAimed(bool isAimed)
    { 
        if(_isFollowed == false)
            _rawImage.enabled = isAimed;
    }
}
