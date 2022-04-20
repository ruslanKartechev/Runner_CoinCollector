using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame.Controlls;
namespace RunnerGame
{
    [System.Serializable]
    public class CharachterAnimationSettings
    {
        public float IdleRunTime = 0.3f;
        public string IdleRunBlend = "IdleRunBlend";

        public string RunSpeedParam = "RunSpeed";
        public float RunPlaySpeed = 0.5f;
    }

    public class CharachterAnimationManager : MonoBehaviour
    {
        public Animator mAnim;
        private InputObservableBase inputEvents;
        private bool Started = false;

        [SerializeField] private CharachterAnimationSettings _settings;
        private Coroutine _idleRunBlending;
        private void Awake()
        {
            inputEvents = FindObjectOfType<InputObservableBase>();
            if (inputEvents == null) { Debug.LogError("Input Events Observable not found"); return; }
       
        }

        public void TurnOn()
        {
            SubscribeMoveEvents();
        }
        public void TurnOff()
        {
            UnsubscribeMoveEvents();
        }
        public void Win()
        {
            mAnim.Play("Dance", 0, 0);
        }


        public void Init(Animator anim, CharachterAnimationSettings settings)
        {
            mAnim = anim;
            _settings = settings;
            mAnim.SetFloat(_settings.RunSpeedParam, _settings.RunPlaySpeed);
        }

        private void SubscribeMoveEvents()
        {
            inputEvents.Clicked += OnClick;
            inputEvents.Released += OnRelease;
        }

        private void UnsubscribeMoveEvents()
        {
            inputEvents.Clicked -= OnClick;
            inputEvents.Released -= OnRelease;
        }

        private void OnClick()
        {
            if(Started == false)
            {
                Started = true;
                mAnim.Play("IdleRun", 0, 0);
            }
            if (_idleRunBlending != null) StopCoroutine(_idleRunBlending);
            _idleRunBlending = StartCoroutine(IdleRunBlending(1));
        }

        private void OnRelease()
        {
            mAnim.Play("Idle", 0, 0);
            if (_idleRunBlending != null) StopCoroutine(_idleRunBlending);
            _idleRunBlending = StartCoroutine(IdleRunBlending(0));
        }

        private IEnumerator IdleRunBlending(float endVal)
        {
            float elapsed = 0f;
            endVal = Mathf.Clamp01(endVal);
            float startVal = mAnim.GetFloat(_settings.IdleRunBlend);
            float time = Mathf.Abs(endVal - startVal) * _settings.IdleRunTime;
            while(elapsed <= time)
            {
                float t = Mathf.Lerp(startVal, endVal, elapsed / time);
                mAnim.SetFloat(_settings.IdleRunBlend, t);
                elapsed += Time.deltaTime;
                yield return null;
            }
            mAnim.SetFloat(_settings.IdleRunBlend, endVal);
        }

        private void OnDestroy()
        {
            UnsubscribeMoveEvents();
        }

    }
}