using UnityEngine;

public class ShootButton : MonoBehaviour
{
    private float _timeForInvoke = .01f;
    public bool IsClickShoot { get; private set; }

    public void Shoot()
    {
        IsClickShoot = true;
        Invoke("DisableShoot", _timeForInvoke);
    }

    private void DisableShoot()
    {
        IsClickShoot = false;
    }
}
