using UnityEngine;
using UnityEngine.UI;
using YG;

public class Sensitivity : MonoBehaviour
{
    private Slider _slider;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _slider.value = YG2.saves.sensitivityMobile;
    }

    public void ChangeValue()
    {
         YG2.saves.sensitivityMobile = _slider.value;
    }
}
