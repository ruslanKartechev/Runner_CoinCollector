using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
namespace RunnerGame
{
    public class FinishController : MonoBehaviour
    {

        public FinishCollisionManager _collisionManager;
        public ConfettiManager _confetti;
        private void Awake()
        {
            _collisionManager.OnActivated = OnFinish;
            _confetti.StopAll();
        }

        public void OnFinish()
        {
            _confetti.ShootLoop();
        }

    }
}