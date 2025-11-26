using UnityEngine;

public class Screenshot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ScreenCapture.CaptureScreenshot("D:\\GameScrinshot\\sniper5.png");
    }
}
