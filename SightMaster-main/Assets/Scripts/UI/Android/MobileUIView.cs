using UnityEngine;

public class MobileUIView : MonoBehaviour
{
    private void Awake()
    {
        if(Application.isMobilePlatform == false)
            Destroy(gameObject);
    }
}
