using UnityEngine;
using UnityEngine.EventSystems;

namespace SightMaster.Scripts.UI
{
    public class UIBlocker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsUIBeingTouched { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsUIBeingTouched = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsUIBeingTouched = false;
        }
    }
}