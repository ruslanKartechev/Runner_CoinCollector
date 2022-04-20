using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public abstract class CoinAnimatorBase : MonoBehaviour
    {
        public abstract void Init(object settings);
        public abstract void OnStart();
        public abstract void OnCollected();
        public abstract void OnHide();

    }
}