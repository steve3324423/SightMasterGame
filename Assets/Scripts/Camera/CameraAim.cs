using SightMaster.Scripts.Player;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.CameraHandlers
{
    public class CameraAim : MonoBehaviour
    {
        private IInput _input;

        [Inject]
        public void Construct(IInput input)
        {
            _input = input;
        }

        private void Update()
        {
            transform.localRotation = Quaternion.Euler(_input.Pitch, 0, 0);
        }
    }
}
