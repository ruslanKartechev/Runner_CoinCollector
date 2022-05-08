using System.Collections;
using UnityEngine;
using CommonGame.Controlls;
namespace RunnerGame
{
    public class ClickDragCharachterMover : CharachterMoverBase
    {
        [SerializeField] private InputEventsSO inputEvents;
        private CharachterMovementSettings _settings;
        private float currentSpeed = 0;

        private Coroutine _moving;
        private Coroutine _speedChaning;

        private void Awake()
        {
        }
        public override void Init(object settings)
        {
            _settings = (CharachterMovementSettings)settings;
        }

        public override void TurnOn()
        {
            Subscrive();
        }
        public override void TurnOff()
        {
            Unsubscribe();
        }

        public override void StartMovement()
        {
            if (_moving != null) StopCoroutine(_moving);
            _moving = StartCoroutine(MovingForward());
        }
        public override void StopMovement()
        {
            if (_moving != null) StopCoroutine(_moving);
            _moving = null;
            currentSpeed = 0;
        }

        private void Subscrive()
        {
            if (inputEvents == null)
            {
                Debug.Log("input channel not assigned");
                return;
            }
            inputEvents.OnClick += OnClick;
            inputEvents.OnRelease += OnRelease;
            inputEvents.OnDrag += OnMouseMove;
        }
        private void Unsubscribe()
        {
            if (inputEvents == null)
            {
                Debug.Log("input channel not assigned");
                return;
            }
            inputEvents.OnClick -= OnClick;
            inputEvents.OnRelease -= OnRelease;
            inputEvents.OnDrag -= OnMouseMove;
        }
        private void OnClick()
        {
            if(_moving == null) _moving = StartCoroutine(MovingForward());
            if (_speedChaning != null) StopCoroutine(_speedChaning);
            _speedChaning = StartCoroutine(SpeedChaning(_settings.MainSpeed, _settings.RunStartTime));
        }
        private void OnRelease()
        {
            if (_speedChaning != null) StopCoroutine(_speedChaning);
            _speedChaning = StartCoroutine(SpeedChaning(0, _settings.RunStopTime));


        }
        private void OnMouseMove(Vector2 input)
        {
            if(input.x < 0)
            {
                float x = transform.position.x - Time.deltaTime * _settings.SideMoveSpeed;
                if (Mathf.Abs(x) > _settings.MaxSideOffset) {/* Debug.Log("offset max");*/ return; }
                    
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            } else if(input.x > 0)
            {
                float x = transform.position.x + Time.deltaTime * _settings.SideMoveSpeed;
                if (Mathf.Abs(x) > _settings.MaxSideOffset)
                    return;
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            } 
        }

        private IEnumerator MovingForward()
        {
            while (true)
            {
                if (currentSpeed == 0)
                    yield return null;
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    transform.position.z + _settings.SideMoveSpeed * Time.deltaTime * currentSpeed);
                yield return null;
            }
        }
        private IEnumerator SpeedChaning(float endVal, float time)
        {
            float elapsed = 0f;
            float startVal = currentSpeed;
            if(time == 0)
            {
                currentSpeed = endVal;
                yield break;
            }
            while(elapsed <= time)
            {
                currentSpeed = Mathf.Lerp(startVal, endVal, elapsed / time);
                elapsed += Time.deltaTime;
                yield return null;
            }
            currentSpeed = endVal;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}