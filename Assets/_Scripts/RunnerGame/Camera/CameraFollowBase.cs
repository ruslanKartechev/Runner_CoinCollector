using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraFollowBase : MonoBehaviour
{
    public abstract void Init(object settings);
    public abstract void SetTarget(object target);
    public abstract void StartFollowing();
    public abstract void StopFollowing();
    public abstract void SetInitalPosition();
    public abstract void SetFollowPosition();
    public abstract void SetFinishPosition();
}
