using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame.Controlls
{
    public class ClickDragInput : MonoBehaviour
    {

        [SerializeField] private InputEventsSO _inputChannel;
        private Coroutine InputCheck;
        private Coroutine _mouseDeltaCheck;

        private void Start()
        {
            StartInputCheck();
        }

        protected void StartInputCheck()
        {
            StopInputCheck();
            InputCheck = StartCoroutine(InputChecking());
        }

        protected void StopInputCheck()
        {
            if (InputCheck != null) StopCoroutine(InputCheck);
            InputCheck = null;
            if (_mouseDeltaCheck != null) StopCoroutine(_mouseDeltaCheck);
            _mouseDeltaCheck = null;
        }
        protected void OnClick()
        {

            if (_mouseDeltaCheck != null)
            {
                StopCoroutine(_mouseDeltaCheck);
                _mouseDeltaCheck = null;
            }
            _mouseDeltaCheck = StartCoroutine(MouseDeltaCheking());
            _inputChannel?.RaiseEventClick();
        }
        protected void OnRelease()
        {

            if (_mouseDeltaCheck != null)
            {
                StopCoroutine(_mouseDeltaCheck); _mouseDeltaCheck = null;
            }
            _inputChannel?.RaiseEventRelease();

        }
        protected IEnumerator InputChecking()
        {
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    OnClick();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    OnRelease();
                }
                yield return null;
            }
        }

        protected IEnumerator MouseDeltaCheking()
        {
            float sensitivity = 1;
            Vector2 pointerOldPos = Input.mousePosition;
            Vector2 pointerNewPos = new Vector2();
            while (Input.GetMouseButton(0))
            {
                pointerNewPos = Input.mousePosition;
                Vector2 d = (pointerNewPos - pointerOldPos);
                float distance = d.magnitude;
                Vector2 move = d * sensitivity;
                if (distance < move.magnitude)
                    move = d;
                _inputChannel?.RaiseEventDrag(move);
                pointerOldPos = pointerNewPos;
                yield return null;
            }
        }

    }
}