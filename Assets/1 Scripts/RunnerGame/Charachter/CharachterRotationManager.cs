using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame.Controlls;
using System;
namespace RunnerGame
{
    public enum CharachterOrientation { Forward, Left, Right }
    public class CharachterRotationManager : CharachterRotatorBase
    {
        private InputObservableBase inputEvents;
        private CharachterMovementSettings _settings;

        private Coroutine _turningForward;
        private Coroutine _turningToAngle;
        private CharachterOrientation currentTurn = CharachterOrientation.Forward;
        private void Awake()
        {
            inputEvents = FindObjectOfType<InputObservableBase>();
        }
        public override void Init(object settings)
        {
            _settings = (CharachterMovementSettings)settings;
        }

        public override void TurnOn()
        {
            SubscribeToEvents();
        }
        public override  void TurnOff()
        {
            Unsubscribe();
            TurnForward();
        }

        private void SubscribeToEvents()
        {
            inputEvents.Clicked += OnClick;
            inputEvents.Released += OnRelease;
            inputEvents.MouseMove += OnMouseMove;
        }
        private void Unsubscribe()
        {
            inputEvents.Clicked -= OnClick;
            inputEvents.Released -= OnRelease;
            inputEvents.MouseMove -= OnMouseMove;
        }
        private void OnClick()
        {

        }
        private void OnRelease()
        {
            HandleTurn(0);
        }

        float TimeThreshold = 0.05f;
        float timeElapsed = 0;
        private void OnMouseMove(Vector2 input)
        {
            if (input.x < 0)
            {
                timeElapsed = 0;
                HandleTurn(-1);
            }
            else if (input.x > 0)
            {
                timeElapsed = 0;
                HandleTurn(1);
            }
            else if (input.x == 0)
            {
                timeElapsed += Time.deltaTime; ;
                if(timeElapsed >= TimeThreshold)
                {
                    timeElapsed = 0;
                    TurnForward();
                }
            }

        }

        private void HandleTurn(int dir)
        {
            switch (dir)
            {
                case 1:
                    TurnLeft();
                    break;
                case (-1):
                    TurnRight();
                    break;
                case 0:
                    TurnForward();
                    break;
            }
        }


        public void TurnLeft()
        {
            if (currentTurn != CharachterOrientation.Left)
            {
                if (_turningToAngle != null) StopCoroutine(_turningToAngle);
                if (_turningForward != null) StopCoroutine(_turningForward);
                _turningForward = StartCoroutine(TurningToZero(StartLeftTurn));
                currentTurn = CharachterOrientation.Left;
            }
        }
        public void TurnRight()
        {
            if (currentTurn != CharachterOrientation.Right)
            {
                currentTurn = CharachterOrientation.Right;
                if (_turningToAngle != null) StopCoroutine(_turningToAngle);
                if (_turningForward != null) StopCoroutine(_turningForward);
                _turningForward = StartCoroutine(TurningToZero(StartRightTurn));
            }
        }
        public void TurnForward()
        {
            if (currentTurn != CharachterOrientation.Forward)
            {
                if (_turningToAngle != null) StopCoroutine(_turningToAngle);
                if (_turningForward != null) StopCoroutine(_turningForward);
                _turningForward = StartCoroutine(TurningToZero());
                currentTurn = CharachterOrientation.Forward;
            }
        }
        public override void TurnToCamera()
        {
            if (_turningToAngle != null) StopCoroutine(_turningToAngle);
            if (_turningForward != null) StopCoroutine(_turningForward);
            _turningForward = StartCoroutine(TurningToZero(StartBackwardTurn));
        }

        private void StartLeftTurn()
        {
            if (_turningToAngle != null) StopCoroutine(_turningToAngle);
            _turningToAngle = StartCoroutine(TurningFromZero(_settings.TurnAngle));
        }
        private void StartRightTurn()
        {
            if (_turningToAngle != null) StopCoroutine(_turningToAngle);
            _turningToAngle = StartCoroutine(TurningFromZero(-_settings.TurnAngle));

        }
        private void StartBackwardTurn()
        {
            if (_turningToAngle != null) StopCoroutine(_turningToAngle);
            _turningToAngle = StartCoroutine(TurningFromZero(179));
        }


        private IEnumerator TurningFromZero(float finalAngle)
        {
            float elapsed = 0f;
            float startAngle = 0f;
            float time = Mathf.Abs(finalAngle) / _settings.TurnAngle * _settings.TurnTime;
            if (time == 0)
                yield break;
            while (elapsed <= time)
            {
                float angle = Mathf.Lerp(startAngle, finalAngle, elapsed / time);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, finalAngle, transform.eulerAngles.z);
        }

        private IEnumerator TurningToZero(Action onEnd = null)
        {
            float elapsed = 0f;
            float time = 1f;
            float startAngle = transform.eulerAngles.y;
            if (startAngle == 0)
            {
                onEnd?.Invoke();
                yield break;
            }

            if (startAngle <= 180)
                time = Mathf.Abs(startAngle) / _settings.TurnAngle * _settings.TurnTime;
            else
                time = Mathf.Abs(360 - startAngle) / _settings.TurnAngle * _settings.TurnTime;

            float finalangle = 0f;
            if (startAngle > 180)
                finalangle = 360;
            if (time == 0)
            {
                onEnd?.Invoke();
                yield break;
            }
            while (elapsed <= time)
            {
                float angle = Mathf.Lerp(startAngle, finalangle, elapsed / time);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            _turningForward = null;
            onEnd?.Invoke();
        }

    }
}