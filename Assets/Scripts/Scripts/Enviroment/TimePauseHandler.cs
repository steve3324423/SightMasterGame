using UnityEngine;

namespace SightMaster.Scripts.Enviroment
{
    public class TimePauseHandler : MonoBehaviour
    {
        private void Awake()
        {
            if (Time.timeScale <= 0)
                Time.timeScale = 1;
        }
    }
}
