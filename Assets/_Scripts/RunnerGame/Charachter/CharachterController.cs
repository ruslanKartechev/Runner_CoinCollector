using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
using CommonGame.Events;
namespace RunnerGame
{
    public enum CollisionMessages { Coin, Finish }
    public class CharachterController : MonoBehaviour, ICameraTarget
    {
        public CharachterComponents _components;
        [Space(5)]
        [SerializeField] private CameraTargetSO _cameraTargetChannel;
        [SerializeField] private LevelStartChannelSO _startChannel;
        [SerializeField] private LevelFinishChannelSO _finishChannel;
        private void Awake()
        {
            _cameraTargetChannel?.SetTarget(this);
        }
        private void Start()
        {
            if (_components == null)
                _components = GetComponent<CharachterComponents>();
            _components._MoveManager.Init(_components._MoverSettings);
            _components._RotationManager.Init(_components._MoverSettings);
            _components._collisionManager.Init(this);
            _components._AnimManager.Init(_components.CharacterAnimator, _components._AnimationSettings);
            _startChannel.OnLevelStarted?.AddListener(OnLevelStart);
            ScoreKeeperController.Instance.Refresh();
        }

        private void OnLevelStart()
        {
            _components._MoveManager.TurnOn();
            _components._RotationManager.TurnOn();
            _components._AnimManager.TurnOn();
        }

        public Transform GetTransform() { return transform; }

        public void HandleCollision(CollisionMessages message, object source)
        {
            switch (message)
            {
                case CollisionMessages.Coin:
                    ICollectable c = (ICollectable)source;
                    c?.Collect();
                    ScoreKeeperController.Instance.OnCoinCollected();
                    break;
                case CollisionMessages.Finish:
                    ICheckPoint cp = (ICheckPoint)source;
                    if (cp != null)
                        cp.Activate();
                    OnFinish();
                    break;
            }
        }

        private void OnFinish()
        {
            _components._MoveManager.TurnOff();
            _components._MoveManager.StopMovement();
            _components._RotationManager.TurnOff();
            _components._AnimManager.Win();
            _components._AnimManager.TurnOff();
            _finishChannel?.RaiseEvent();
        }
    }
}