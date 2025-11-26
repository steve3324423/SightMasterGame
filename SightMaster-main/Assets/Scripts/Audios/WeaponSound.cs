using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponSound : MonoBehaviour
{
    [SerializeField] private WeaponAmmo[] _ammos;

    private AudioSource _audioSource;
    private AudioClip _clip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        foreach (WeaponAmmo ammo in _ammos)
            ammo.Shooted += OnShooted;
    }

    private void OnDisable()
    {
        foreach (WeaponAmmo ammo in _ammos)
            ammo.Shooted -= OnShooted;
    }

    private void SetClip()
    {
        foreach (WeaponAmmo ammo in _ammos)
        {
            if (ammo.gameObject.activeSelf)
                _audioSource.clip = ammo.GetComponent<SoundGet>().GetClip(); ;
        }
    }

    private void OnShooted()
    {
        if (_audioSource.clip == null)
            SetClip();

        _audioSource.Play();
    }
}
