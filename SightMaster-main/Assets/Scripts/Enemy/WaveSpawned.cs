using System;
using System.Collections.Generic;
using UnityEngine;

namespace SightMaster.Scripts.Enemy
{
    public class WaveSpawned : MonoBehaviour
    {
        [SerializeField] private bool _isDisabled = true;

        private float _timeForInvoke = 3f;

        public event Action<List<GameObject>> WarningBeforeSpawned;
        public event Action Activated;

        private void Start()
        {
            if (_isDisabled)
                ResetEnemies(false);
        }

        public void Start—ountdown()
        {
            List<GameObject> directChildren = GetDirectChildren(transform);
            WarningBeforeSpawned?.Invoke(directChildren);
            Invoke("Spawned", _timeForInvoke);
        }

        private void Spawned()
        {
            ResetEnemies(true);
            Activated?.Invoke();
        }

        private void ResetEnemies(bool enabled)
        {
            foreach (Transform child in transform)
            {
                if (child != null)
                    child.gameObject.SetActive(enabled);
            }
        }

        public List<GameObject> GetDirectChildren(Transform parentTransform)
        {
            List<GameObject> children = new List<GameObject>();
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                Transform childTransform = parentTransform.GetChild(i);
                children.Add(childTransform.gameObject);
            }

            return children;
        }
    }
}