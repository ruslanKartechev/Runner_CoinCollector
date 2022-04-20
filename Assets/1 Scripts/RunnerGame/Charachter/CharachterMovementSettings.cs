using System;
using System.Collections.Generic;
using UnityEngine;
namespace RunnerGame
{
    [CreateAssetMenu(fileName = "CharMoverSettings", menuName = "ScriptableObjects/CharMoverSettings", order = 1)]
    public class CharachterMovementSettings : ScriptableObject
    {
        public float MainSpeed = 1f;
        public float StartAccelerationTime = 0.4f;
        public float SideMoveSpeed = 1f;
        public float MaxSideOffset = 4f;
        [Space(10)]
        public float RunStopTime = 0.2f;
        public float RunStartTime = 0.2f;
        [Space(10)]
        public float TurnAngle = 30f;
        public float TurnTime = 0.2f;
    }
}
