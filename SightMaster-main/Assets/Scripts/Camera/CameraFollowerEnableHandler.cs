using UnityEngine;

public class CameraFollowerEnableHandler : CameraEnableHandler
{
    protected override void OnWined()
    {
        if (IsFollowed == false)
            Camera.enabled = true;
    }

    protected override void OnFollowed(bool isFollowed)
    {
        Camera.enabled = isFollowed;
        IsFollowed = isFollowed;
    }

    protected override void OnAimed(bool isAimed)
    {
        if(IsFollowed == false)
            Camera.enabled = !isAimed;
    }
}
