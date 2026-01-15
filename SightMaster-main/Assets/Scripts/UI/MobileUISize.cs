using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class MobileUISize : MonoBehaviour
    {
        [SerializeField] private float _valueIncrease = 2f;

        private void Awake()
        {
            if (Application.isMobilePlatform)
                transform.localScale *= _valueIncrease;
        }
    }
}
