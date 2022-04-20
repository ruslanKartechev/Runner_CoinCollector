using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CoinAnimator : CoinAnimatorBase
    {
        public Animator mAnim;
        public override void Init(object settings)
        {

        }

        public override void OnCollected()
        {
            mAnim.StopPlayback();
            mAnim.enabled = false;

        }

        public override void OnHide()
        {
            mAnim.StopPlayback();
        }

        public override void OnStart()
        {
            mAnim.Play("CoinSpin", 0, UnityEngine.Random.Range(0f, 1f));
        }

    }
}