using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
using CommonGame.Events;
namespace RunnerGame
{
    [System.Serializable]
    public class CameraTarget
    {
        public Transform FollowTarget;
        public Transform AimTarget;
    }
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraSettings _settings;
        [SerializeField] private CameraFollowBase _follower;
        [Space(5)]

        [SerializeField] private CameraTargetSO _cameraTargetChannel;
        [SerializeField] private LevelStartChannelSO _startChannel;
        [SerializeField] private LevelFinishChannelSO _finishChannel;
        [SerializeField] private LevelLoadChannelSO _loadChannel;

        private CameraTarget currentTarget;

        private void Awake()
        {
            _follower.Init(_settings._CameraSettings);
            currentTarget = new CameraTarget();
            _startChannel?.OnLevelStarted.AddListener(OnLevelStart);
            _finishChannel?.OnLevelFinished.AddListener(OnLevelEnd);
            _loadChannel.OnLevelLoaded += OnNewLevel;

        }

        private void OnNewLevel(int level)
        {
            if (_cameraTargetChannel == null) { Debug.LogError("Camera target not assigned"); return; }
            InitMoverStart();
        }

        private void OnLevelStart()
        {
            InitMoverMain();
        }
        private void OnLevelEnd()
        {
            InitMoverFinish();
        }

        // Mover Positions
        public void InitMoverStart()
        {
            currentTarget.AimTarget = _cameraTargetChannel.GetTarget().GetTransform();
            currentTarget.FollowTarget = _cameraTargetChannel.GetTarget().GetTransform();
            _follower.StartFollowing();
            _follower.SetTarget(currentTarget);
            _follower.SetInitalPosition();
        }
        public void InitMoverMain()
        {
            _follower.SetFollowPosition();

        }
        public void InitMoverFinish()
        {
            _follower.SetFinishPosition();
        }

    }
}
