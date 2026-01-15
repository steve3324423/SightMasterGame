using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SightMaster.Scripts.UI
{
    public class UITouchControl : MonoBehaviour, IBeginDragHandler, IEndDragHandler
    {
        public event Action<bool> Touched;

        public void OnBeginDrag(PointerEventData eventData)
        {
            Touched?.Invoke(true);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Touched?.Invoke(false);
        }
    }
}