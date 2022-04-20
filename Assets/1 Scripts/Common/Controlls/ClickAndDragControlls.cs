using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CommonGame.Controlls
{

    public class ClickAndDragControlls : ControllsManagerBase
    {
        private Coroutine _mouseDeltaCheck;
        public override void EnableControlls()
        {
            StartInputCheck();
        }
        public override void DisableControlls()
        {
            StopInputCheck();
        }
        protected override void OnClick()
        {
            FireEvent(InputTypes.Click,null);
            if (_mouseDeltaCheck != null) { StopCoroutine(_mouseDeltaCheck); _mouseDeltaCheck = null; }
            _mouseDeltaCheck = StartCoroutine(MouseDeltaCheking());
        }
        protected override void OnRelease()
        {
            FireEvent(InputTypes.Release, null);
            if (_mouseDeltaCheck != null) { StopCoroutine(_mouseDeltaCheck); _mouseDeltaCheck = null; }
        }
        protected void OnMouseInput(Vector2 input)
        {
            FireEvent(InputTypes.MouseMove, input);
        }


        #region InputCheck
        protected override IEnumerator InputChecking()
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

        protected override void StartInputCheck()
        {
            StopInputCheck();
            InputCheck = StartCoroutine(InputChecking());
        }

        protected override void StopInputCheck()
        {
            if (InputCheck != null) StopCoroutine(InputCheck);
            InputCheck = null;
            if (_mouseDeltaCheck != null) StopCoroutine(_mouseDeltaCheck);
            _mouseDeltaCheck = null;
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
                OnMouseInput(move);

                pointerOldPos = pointerNewPos;
                yield return null;
            }
        }
        #endregion

        #region NotUsed
        public override void Init(object ui)
        {

        }
        public override void ShowControlls()
        {
            throw new System.NotImplementedException();
        }

        public override void HideControlls()
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}