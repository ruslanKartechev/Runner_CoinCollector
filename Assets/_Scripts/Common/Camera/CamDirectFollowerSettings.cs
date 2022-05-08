using UnityEngine;
namespace CommonGame
{


    [CreateAssetMenu(fileName = "DirectFollowerSettings", menuName = "ScriptableObjects/DirectFollowerSettings", order = 1)]
    public class CamDirectFollowerSettings : ScriptableObject
    {
        [Header("Time")]
        public float OffsetChangeTime;
        public float AngleChangeTime;
        [Header("Side Movement")]
        public float MinSideOffset = 0.35f;
        public float MaxSideOffset = 0.75f;
        [Header("start")]
        public Vector3 StartOffset;
        public Vector3 StartEulers;
        [Header("Main")]
        public Vector3 MainOffset;
        public Vector3 MainEulers;

    }
}
