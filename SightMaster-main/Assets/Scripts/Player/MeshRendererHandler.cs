using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public class MeshRendererHandler : MeshHandler
    {
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        protected override void OnAimed(bool isAimed)
        {
            _meshRenderer.enabled = !isAimed;
        }
    }
}
