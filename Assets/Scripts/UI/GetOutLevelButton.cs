using UnityEngine;
using YG;

namespace SightMaster.Scripts.UI
{
    public class GetOutLevelButton : MonoBehaviour
    {
        public void Touched()
        {
            YandexGame.FullscreenShow();
        }
    }
}
