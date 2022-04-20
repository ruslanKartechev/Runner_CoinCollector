using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace RunnerGame
{
    
    public class CoinCollisionManager : MonoBehaviour, ICollectable
    {
        public Action CollisionNotifier;
        public Action onCollect = null;

        public void Enable()
        {
            onCollect = NotifyCollected;
        }
        public void Disable()
        {
            onCollect = null;
        }
        public void NotifyCollected()
        {
            CollisionNotifier?.Invoke();
        }
        public void Collect()
        {
            onCollect?.Invoke();
        }
    }
}