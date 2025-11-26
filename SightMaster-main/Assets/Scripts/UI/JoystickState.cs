using UI_Inputs;
using UnityEngine;

public class JoystickState : MonoBehaviour
{
    [SerializeField] private UIInputJoystick _movementJoystick;
    [SerializeField] private Aim _aim;

    private void OnEnable()
    {
        _aim.Aimed += OnAimed;
    }

    private void OnDisable()
    {
        _aim.Aimed -= OnAimed;
    }

    private void OnAimed(bool isAimed)
    {
        if(Application.isMobilePlatform)
            _movementJoystick.gameObject.SetActive(!isAimed);
    }
}
