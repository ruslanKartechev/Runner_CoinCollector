using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
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
        private CameraTarget currentTarget;

        private void Awake()
        {
            _follower.Init(_settings._CameraSettings);
            GameManager.Instance._events.LevelLoaded.AddListener(OnNewLevel);
            GameManager.Instance._events.LevelStarted.AddListener(OnLevelStart);
            GameManager.Instance._events.LevelEndReached.AddListener(OnLevelEnd);
            currentTarget = new CameraTarget();
        }

        private void OnNewLevel()
        {
            if (GameManager.Instance._data._charachterTarget == null) { Debug.LogError("CHARACHTER FOLLOW TARGET NOT FOUND"); return; }
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
            currentTarget.AimTarget = GameManager.Instance._data._charachterTarget.GetTransform();
            currentTarget.FollowTarget = GameManager.Instance._data._charachterTarget.GetTransform();
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
