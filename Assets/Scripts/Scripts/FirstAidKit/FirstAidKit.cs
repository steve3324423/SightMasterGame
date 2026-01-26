using System;
using SightMaster.Scripts.Player;
using UnityEngine;

namespace SightMaster.Scripts.FirstAidKit
{
    public class FirstAidKit : MonoBehaviour
    {
        [SerializeField] private float _timeForInvoke = 90f;

        private int _maxValue = 100;

        public event Action Spawned;
        public event Action Taked;

        private void Awake()
        {
            gameObject.SetActive(false);
            Invoke("EnableFirstAid", _timeForInvoke);
        }

        private void EnableFirstAid()
        {
            gameObject.SetActive(true);
            Spawned?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth player) && player.CurrentHealth < _maxValue)
            {
                Taked?.Invoke();
                player.SetHealth(_maxValue);
                Destroy(gameObject);
            }
        }
    }
}
