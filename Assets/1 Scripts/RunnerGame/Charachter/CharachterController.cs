using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
namespace RunnerGame
{
    public enum CollisionMessages { Coin, Finish }
    public class CharachterController : MonoBehaviour, ICameraTarget
    {
        public CharachterComponents _components;
        private void Start()
        {
            GameManager.Instance._data._charachterTarget = this;
            if (_components == null)
                _components = GetComponent<CharachterComponents>();
            _components._MoveManager.Init(_components._MoverSettings);
            _components._RotationManager.Init(_components._MoverSettings);
            _components._collisionManager.Init(this);
            _components._AnimManager.Init(_components.CharacterAnimator, _components._AnimationSettings);
            GameManager.Instance._events.LevelStarted.AddListener(OnLevelStart);
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
          //  _components._RotationManager.TurnToCamera();
            _components._AnimManager.Win();
            _components._AnimManager.TurnOff();
            GameManager.Instance._events.PlayerWin.Invoke();
            GameManager.Instance._events.LevelEndReached.Invoke();
        }
    }
}