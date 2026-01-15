using UnityEngine;

namespace SightMaster.Scripts.UI.Android
{
    public class MobileUIView : MonoBehaviour
    {
        private void Awake()
        {
            if (Application.isMobilePlatform == false)
                Destroy(gameObject);
        }
    }
}
