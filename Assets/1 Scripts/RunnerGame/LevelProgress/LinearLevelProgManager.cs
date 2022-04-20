using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class LinearLevelProgManager : ProgressManagerBase
    {

        private Vector3 startPos;
        private Vector3 finishPos;

        private Vector3 TrackVector;
        private float trackLength;
        private Transform charachter;
        public override void InitNewLevel()
        {
            _progress = 0;
            charachter = FindObjectOfType<CharachterController>().transform;
            startPos = charachter.position;
            finishPos = GameObject.FindGameObjectWithTag(Tags.Finish).transform.position;
            TrackVector = finishPos - startPos;
            trackLength = TrackVector.magnitude;
            TrackVector = TrackVector.normalized;
        }
        public override float CheckProgress()
        {
            Vector3 dist = (charachter.position - startPos);
            float projection = Vector3.Dot(dist,TrackVector);
            _progress = projection / trackLength;
            return _progress;
        }
    }
}