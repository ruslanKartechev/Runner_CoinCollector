using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public abstract class ProgressManagerBase : MonoBehaviour
    {
        protected float _progress;
        public float CurrentProgress { get { return _progress; } }
        public abstract void InitNewLevel();
        public abstract float CheckProgress();

    }
}