using System;
using System.Collections;
using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.Enemy;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public class VisiblePlayer : MonoBehaviour
    {
        [SerializeField] private DepletionPlayer _depletionPlayer;
        [SerializeField] private Transform _cameraAim;
        [SerializeField] private LayerMask _layerMask;

        private LayerMask _actualLayerMask;
        private Ray _ray;
        private RaycastHit _hit;

        public Action<bool> PlayerDisappeared;

        private void Awake()
        {
            _actualLayerMask = ~_layerMask;
        }

        private void OnEnable()
        {
            _depletionPlayer.Depleted += OnDepleted;
        }

        private void OnDisable()
        {
            _depletionPlayer.Depleted -= OnDepleted;
        }

        private IEnumerator Tracked()
        {
            while (enabled)
            {
                Vector3 directionToPlayer = (_cameraAim.transform.position - transform.position).normalized;
                _ray = new Ray(transform.position, directionToPlayer);

                if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, _actualLayerMask))
                    PlayerDisappeared?.Invoke(_hit.transform.TryGetComponent(out CameraAim camera));

                yield return null;
            }
        }

        private void OnDepleted()
        {
            StartCoroutine(Tracked());
        }
    }
}
