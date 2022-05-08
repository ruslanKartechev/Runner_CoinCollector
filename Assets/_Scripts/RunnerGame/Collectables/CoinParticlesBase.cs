using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public abstract class CoinParticlesBase : MonoBehaviour
    {
        public abstract void PlayParticles();
        public abstract void StopParticles();
        public abstract void Init(object settings);

    }
}