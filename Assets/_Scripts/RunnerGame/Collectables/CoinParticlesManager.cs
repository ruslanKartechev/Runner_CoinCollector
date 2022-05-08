using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CoinParticlesManager : CoinParticlesBase
    {
        public List<ParticleSystem> _particles = new List<ParticleSystem>();

        public override void Init(object settings)
        {
            foreach(ParticleSystem p in _particles)
            {
                ParticleSystem.MainModule m = p.main;
                m.playOnAwake = false;
                m.loop = false;
            }
        }

        public override void PlayParticles()
        {
            foreach (ParticleSystem p in _particles)
            {
                p.Play();
            }
        }

        public override void StopParticles()
        {
            foreach (ParticleSystem p in _particles)
            {
                p.Stop();
            }
        }
    }
}