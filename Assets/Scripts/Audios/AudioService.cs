using UnityEngine;

namespace SightMaster.Scripts.Audios
{
    public class AudioService : MonoBehaviour
    {
        private static AudioService _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
