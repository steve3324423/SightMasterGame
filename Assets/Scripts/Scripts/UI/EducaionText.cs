using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class EducaionText : MonoBehaviour
    {
        private const string MethodName = "Disable";

        [SerializeField] private float _timeForInvoke = 5f;

        private void Awake()
        {
            if (Application.isMobilePlatform)
                Disable();

            Invoke(MethodName, _timeForInvoke);
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
