using UnityEngine;

namespace SightMaster.Scripts.Weapon.AimHandler
{
    public class SpriteGet : MonoBehaviour
    {
        [SerializeField] private Texture _aim;

        public Texture GetTexture()
        {
            return _aim;
        }
    }
}
