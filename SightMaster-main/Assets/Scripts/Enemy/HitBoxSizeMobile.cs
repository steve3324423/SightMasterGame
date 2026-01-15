using UnityEngine;

namespace SightMaster.Scripts.Enemy
{
    public class HitBoxSizeMobile : MonoBehaviour
    {
        private float _valueIncrease = 1.35f;
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnEnable()
        {
            ResizeTheCollider();
        }

        private void ResizeTheCollider()
        {
            if (Application.isMobilePlatform)
            {
                if (_collider is BoxCollider)
                {
                    ((BoxCollider)_collider).size *= _valueIncrease;
                }
                else if (_collider is CapsuleCollider)
                {
                    CapsuleCollider capsuleCollider = (CapsuleCollider)_collider;
                    capsuleCollider.radius *= _valueIncrease;
                }
            }
        }
    }
}
