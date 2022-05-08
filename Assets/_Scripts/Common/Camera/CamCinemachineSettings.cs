using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame
{
    [CreateAssetMenu(fileName = "CamCimachineSettings", menuName = "ScriptableObjects/CamCimachineSettings", order = 1)]

    public class CamCinemachineSettings : ScriptableObject
    {
        
        public float OffsetChangeTime = 0.5f;
        public float FinishPostionSetTime = 1f;
        [Header("MainOffsets")]
        public Vector3 FollowOffset = new Vector3();
        public Vector3 FollowAimOffset = new Vector3();
        [Header("StartSettings")]
        public Vector3 StartFollowOffset = new Vector3();
        public Vector3 StartAimOffset = new Vector3();
        [Header("FinishSettings")]
        public Vector3 FinishFollowOffset = new Vector3();
        public Vector3 FinishAimOffset = new Vector3();
    }
}