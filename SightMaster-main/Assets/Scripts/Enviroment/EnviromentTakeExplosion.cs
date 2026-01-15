using UnityEngine;

namespace SightMaster.Scripts.Enviroment
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnviromentTakeExplosion : MonoBehaviour, IExplosionDamage
    {
        protected Rigidbody Rigidbody;
        private float _force = 55f;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public virtual void TakeExplosion()
        {
            Rigidbody.isKinematic = false;
            Vector3 randomDirection = Random.onUnitSphere;
            Rigidbody.AddForce(randomDirection * _force, ForceMode.VelocityChange);
        }
    }
}
