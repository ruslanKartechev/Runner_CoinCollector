using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
namespace RunnerGame
{
    public class CameraDirectFollower : CameraFollowBase
    {
        private CamDirectFollowerSettings _settings;
        private Transform FollowTarget;

        private Coroutine _targetFollowing;
        private Coroutine _angleChaning;
        private Coroutine _offsetChanging;
        private Vector3 currentOffset;
        private Vector3 currentEulers;
        public override void Init(object settings)
        {
            _settings = (CamDirectFollowerSettings)settings;
        }

        public override void SetInitalPosition()
        {
            StartOffsetChange(_settings.StartOffset, _settings.OffsetChangeTime);
            StartAngleChange(_settings.StartEulers, _settings.AngleChangeTime);

        }
        public override void SetFinishPosition()
        {
            throw new System.NotImplementedException();
        }

        public void InitFollowPosition()
        {
            StartOffsetChange(_settings.MainOffset, _settings.OffsetChangeTime);
            StartAngleChange(_settings.MainEulers, _settings.AngleChangeTime);
        }
        public override void SetTarget(object target)
        {
            FollowTarget = (Transform)target;
        }

        public override void StartFollowing()
        {
            StopFollowing();
            _targetFollowing = StartCoroutine(TargetFollowing());
        }
        public override void StopFollowing()
        {
            if (_targetFollowing != null) StopCoroutine(_targetFollowing);
            _targetFollowing = null;
        }
        private IEnumerator TargetFollowing()
        {
            if (FollowTarget == null) { Debug.Log("FOLLOW TARGET IS NULL"); yield break; }
            while (true)
            {
                float x = FollowTarget.transform.position.x;
                //if (Mathf.Abs(FollowTarget.transform.position.x) <= _settings.MinSideOffset)
                //    x = transform.position.x;
                if (x > 0 && x > _settings.MaxSideOffset)
                    x = transform.position.x;
                else if (x < 0 && x < -_settings.MaxSideOffset)
                    x = transform.position.x;
                transform.position = new Vector3( x,FollowTarget.transform.position.y, FollowTarget.transform.position.z) + currentOffset;
                yield return null;
            }
        }


        public void StartOffsetChange(Vector3 offset, float time)
        {
            StopOffsetChange();
            StartCoroutine(OffsetChanging(offset, time));
        }
        private void StopOffsetChange()
        {
            if (_offsetChanging != null) StopCoroutine(_offsetChanging);
            _offsetChanging = null;
        }
        private IEnumerator OffsetChanging(Vector3 targetVal, float time)
        {
            if (FollowTarget == null) { Debug.Log("NO FOLOW TARGET"); yield break; }
            Vector3 startVal = (transform.position - FollowTarget.transform.position);
            float elapsed = 0f;
            float speedMod = 1f;
            while(currentOffset != targetVal)
            {
                speedMod -= Time.deltaTime;
                speedMod = Mathf.Clamp(speedMod, 0.1f, 1f);
                currentOffset = Vector3.Lerp(startVal, targetVal, elapsed / time);
                elapsed += Time.deltaTime * speedMod;
                yield return null;
            }
        }

        public void StartAngleChange(Vector3 targetAngles, float time)
        {
            StopAngleChange();
            _angleChaning = StartCoroutine(AngleChanging(targetAngles, time));
        }

        private void StopAngleChange()
        {
            if (_angleChaning != null) StopCoroutine(_angleChaning);
            _angleChaning = null;
        }

        private IEnumerator AngleChanging(Vector3 targetAngles, float time)
        {
            if (FollowTarget == null) { Debug.Log("NO FOLOW TARGET"); yield break; }
            Vector3 startVal = transform.eulerAngles;
            float elapsed = 0f;
            float speedMod = 1f;
            while (transform.eulerAngles != targetAngles)
            {
                speedMod -= Time.deltaTime ;
                speedMod = Mathf.Clamp(speedMod, 0.1f, 1f);
                transform.eulerAngles = Vector3.Lerp(startVal, targetAngles, elapsed / time);
                elapsed += Time.deltaTime * speedMod;
                yield return null;
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public override void SetFollowPosition()
        {
            throw new System.NotImplementedException();
        }
    }
}