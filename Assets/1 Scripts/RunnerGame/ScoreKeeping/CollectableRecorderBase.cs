using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public abstract class CollectableRecorderBase
    {
        protected int _collected = 0;
        public int Collected { get { return _collected; } }
        public abstract void Collect(int num);
        public abstract void Refresh();
    }


}