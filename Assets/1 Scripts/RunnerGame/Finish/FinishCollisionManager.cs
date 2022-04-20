using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace RunnerGame
{


    public class FinishCollisionManager : MonoBehaviour, ICheckPoint
    {
        public Action OnActivated;
        public void Activate()
        {
            OnActivated?.Invoke();
        }
    }
}