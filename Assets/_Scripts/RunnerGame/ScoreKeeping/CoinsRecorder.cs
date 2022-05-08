using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CoinsRecorder : CollectableRecorderBase
    {
        public override void Collect(int num)
        {
            _collected += num;
        }
        public override void Refresh()
        {
            _collected = 0;
        }
    }
}