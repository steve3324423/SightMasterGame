using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class WeaponAmmo : MonoBehaviour
{
    [SerializeField] private int _magazineSize = 30;
    [SerializeField] private Aim _aim;

    private bool _isCanShoot = true;
    private IInputWeapon _inputWeapon;
    private int _currentAmmo;    
    private int _maxAmmo = 120;      
    private int _ammoInReserve;      
    private bool _isAimed;

    public event Action<int, int> BulletChanged;
    public event Action Shooted;

    [Inject]
    public void Construct(IInputWeapon inputWeapon)
    {
        _inputWeapon = inputWeapon;
    }

    private void Awake()
    {
        _currentAmmo = _magazineSize;
        _ammoInReserve = _maxAmmo - _magazineSize;

        BulletChanged?.Invoke(_currentAmmo, _ammoInReserve);
    }

    private void OnEnable()
    {
        _aim.Aimed += OnAimed;
    }

    private void OnDisable()
    {
        _aim.Aimed -= OnAimed;
    }

    private void Update()
    {
        if (_isAimed && _isCanShoot && _inputWeapon.IsShoot())
            Shoot();
    }

    private void Shoot()
    {
        _currentAmmo--;
        BulletChanged?.Invoke(_currentAmmo, _ammoInReserve);
        Shooted?.Invoke();

        if (_currentAmmo == 0 && _ammoInReserve > 0)
            StartCoroutine(Reload());
        else
            StartCoroutine(SetCanShoot());
    }

    private IEnumerator Reload()
    {
        float timeReload = 2f;
        _isCanShoot = false;

        while (timeReload > 0)
        {
            timeReload -= Time.deltaTime;
            yield return null;
        }

        int ammoToReload = Mathf.Min(_magazineSize - _currentAmmo, _ammoInReserve);
        _currentAmmo += ammoToReload;
        _ammoInReserve -= ammoToReload;

        BulletChanged?.Invoke(_currentAmmo, _ammoInReserve);
        _isCanShoot = true;
    }

    private IEnumerator SetCanShoot()
    {
        float time = 1f;
        _isCanShoot = false;

        while(time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        _isCanShoot = true;
    }

    private void OnAimed(bool isAimed)
    {
        _isAimed = isAimed;
    }
}
