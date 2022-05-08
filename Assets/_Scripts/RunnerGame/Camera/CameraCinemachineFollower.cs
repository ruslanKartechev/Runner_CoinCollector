using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
using Cinemachine;
namespace RunnerGame
{
    public class CameraCinemachineFollower : CameraFollowBase
    {
        [SerializeField] private CamCinemachineSettings _settings;
        [SerializeField] private CinemachineVirtualCamera _virtualCam;

        private CinemachineTransposer _transposer;
        private CinemachineComposer _aimComposer;

        private Coroutine _offsetChanging;

        public override void Init(object settings)
        {
            _settings = (CamCinemachineSettings)settings;
            _virtualCam = GetComponent<CinemachineVirtualCamera>();
            _transposer = _virtualCam.GetCinemachineComponent<CinemachineTransposer>();
            _aimComposer = _virtualCam.GetCinemachineComponent<CinemachineComposer>();
        }
        public override void SetInitalPosition()
        {
            //_transposer.m_FollowOffset = _settings.StartFollowOffset;
            ChangeFollowOffset(_settings.StartFollowOffset, _settings.OffsetChangeTime);
            _aimComposer.m_TrackedObjectOffset = _settings.StartAimOffset;
        }
        public override void SetFollowPosition()
        {
            //_transposer.m_FollowOffset = _settings.FollowOffset;
            ChangeFollowOffset(_settings.FollowOffset, _settings.OffsetChangeTime);
            _aimComposer.m_TrackedObjectOffset = _settings.FollowAimOffset;
        }
        public override void SetFinishPosition()
        {
            //_transposer.m_FollowOffset = _settings.FinishFollowOffset;
            ChangeFollowOffset(_settings.FinishFollowOffset, _settings.FinishPostionSetTime);
            _aimComposer.m_TrackedObjectOffset = _settings.FinishAimOffset;
        }
        public override void SetTarget(object target)
        {
            CameraTarget t = (CameraTarget)target;
            _virtualCam.Follow = t.FollowTarget;
            _virtualCam.LookAt = t.AimTarget;
        }

        public override void StartFollowing()
        {
            _virtualCam.enabled = true;
        }
        public override void StopFollowing()
        {
            _virtualCam.enabled = false;

        }



        private void ChangeFollowOffset(Vector3 targetOFfset, float time)
        {
            if (_offsetChanging != null) StopCoroutine(_offsetChanging);
            _offsetChanging = StartCoroutine(FollowOffsetChange(targetOFfset, time));
        }

        private IEnumerator FollowOffsetChange(Vector3 targetVal, float time)
        {
            float elapsed = 0f;
            Vector3 startVal = _transposer.m_FollowOffset;
            while (elapsed <= time)
            {
                _transposer.m_FollowOffset = Vector3.Lerp(startVal, targetVal, elapsed/time);
                elapsed += Time.deltaTime;
                yield return null;
            }
            _transposer.m_FollowOffset = targetVal;

        }



        #region Editor

        public void SetStartOffset()
        {
            _virtualCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = _settings.StartFollowOffset;
            _virtualCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = _settings.StartAimOffset;
        }
        public void SetMainOffset()
        {
            _virtualCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = _settings.FollowOffset;
            _virtualCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = _settings.FollowAimOffset;
        }
        public void SetFinishOffset()
        {
            _virtualCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = _settings.FinishFollowOffset;
            _virtualCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = _settings.FinishAimOffset;
        }
        #endregion


    }
}