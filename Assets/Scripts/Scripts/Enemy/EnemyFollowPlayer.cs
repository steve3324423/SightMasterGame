using SightMaster.Scripts.Player;
using UnityEngine;

namespace SightMaster.Scripts.Enemy
{
    [RequireComponent(typeof(DepletionPlayer))]
    public class EnemyFollowPlayer : MonoBehaviour
    {
        [SerializeField] private Mover _player;

        private DepletionPlayer _depletionPlayer;

        private bool _isDeplection;

        private void Awake()
        {
            _depletionPlayer = GetComponent<DepletionPlayer>();
        }

        private void OnEnable()
        {
            _depletionPlayer.Depleted += OnDepleted;
        }

        private void OnDisable()
        {
            _depletionPlayer.Depleted -= OnDepleted;
        }

        private void Update()
        {
            if (_isDeplection)
                Rotate();
        }

        private void Rotate()
        {
            Vector3 targetDirection = _player.transform.position - transform.position;
            targetDirection.y = 0;

            transform.rotation = Quaternion.LookRotation(targetDirection);
        }

        private void OnDepleted()
        {
            _isDeplection = true;
        }
    }
}
