using UnityEngine;

namespace SightMaster.Scripts.Enviroment
{
    [RequireComponent(typeof(Barrel))]
    public class ExplosionDamage : MonoBehaviour
    {
        [SerializeField] private float _radius = 15f;

        private Barrel _barrel;

        private void Awake()
        {
            _barrel = GetComponent<Barrel>();
        }

        private void OnEnable()
        {
            _barrel.Exploided += OnExploided;
        }

        private void OnDisable()
        {
            _barrel.Exploided -= OnExploided;
        }

        private void OnExploided()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out IExplosionDamage currentObject))
                    currentObject.TakeExplosion();
            }
        }
    }
}