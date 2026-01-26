using System;

namespace SightMaster.Scripts.CameraHandler
{
    public interface ICameraZoom
    {
        event Action<float> ZoomChanged;
        float CurrentZoom { get; }
    }
}