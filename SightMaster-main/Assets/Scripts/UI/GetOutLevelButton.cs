using UnityEngine;
using YG;

public class GetOutLevelButton : MonoBehaviour
{
    public void Touched()
    {
        YandexGame.FullscreenShow();
    }
}
