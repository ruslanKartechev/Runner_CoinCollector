using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame
{
    [CreateAssetMenu(order = 0,  fileName = "CameraTargetSO", menuName = "SO/CameraTargetSO")]
    public class CameraTargetSO : ScriptableObject
    {
        private ICameraTarget _currentTarget;
        public void SetTarget(ICameraTarget target)
        {
            _currentTarget = target;
        }
        public ICameraTarget GetTarget()
        {
            if(_currentTarget == null)
            {
                throw new System.Exception("Camera target not assigned");
            }
            return _currentTarget;
        }
    }
}