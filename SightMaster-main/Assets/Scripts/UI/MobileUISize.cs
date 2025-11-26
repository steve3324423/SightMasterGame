using UnityEngine;

public class MobileUISize : MonoBehaviour
{
    [SerializeField] private float _valueIncrease = 2f;

    private void Awake()
    {
        if(Application.isMobilePlatform)
            transform.localScale *= _valueIncrease;
    }
}
