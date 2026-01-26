using UnityEngine;

namespace SightMaster.Scripts.Enviroment
{
    public class WindmillRotation : MonoBehaviour
    {
        private float _baseRotationSpeed = 30f;
        private float _windSpeedInfluence = 0.5f;
        private float _currentWindSpeed = 0f;
        private Vector3 _rotationAxis = Vector3.forward;

        private void Update()
        {
            float rotationSpeed = _baseRotationSpeed + (_currentWindSpeed * _windSpeedInfluence);
            transform.Rotate(_rotationAxis * rotationSpeed * Time.deltaTime);
        }
    }
}