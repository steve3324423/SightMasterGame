using UnityEngine;

namespace SightMaster.Scripts.Weapon.Aim
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
