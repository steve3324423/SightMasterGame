using UnityEngine;

namespace SightMaster.Scripts.Weapon.Sound
{
    public class SoundGet : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;

        public AudioClip GetClip()
        {
            return _clip;
        }
    }
}
