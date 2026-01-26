using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public class SkinnedMeshHandler : MeshHandler
    {
        private SkinnedMeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<SkinnedMeshRenderer>();
        }

        protected override void OnAimed(bool isAimed)
        {
            _meshRenderer.enabled = !isAimed;
        }
    }
}
