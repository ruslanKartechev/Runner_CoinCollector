using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public abstract class CharachterRotatorBase : MonoBehaviour
    {
        public abstract void Init(object settings);
        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void TurnToCamera();
    }
}