using UnityEngine;

namespace SightMaster.Scripts.SceneTransition
{
    public class Screenshot : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                ScreenCapture.CaptureScreenshot("C:\\SCRGAME\\SCR3.png");
        }
    }
}
