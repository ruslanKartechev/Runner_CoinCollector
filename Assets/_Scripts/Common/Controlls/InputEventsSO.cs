using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CommonGame.Controlls
{
    [CreateAssetMenu(order = 0, fileName = "InputEventsSO", menuName = "SO/InputEventsSO")]

    public class InputEventsSO : ScriptableObject
    {

        public event Action OnClick;
        public event Action OnRelease;
        public event Action<Vector2> OnDrag;
        
        public void RaiseEventClick()
        {
            OnClick?.Invoke();
        }

        public void RaiseEventRelease()
        {
            OnRelease?.Invoke();
        }

        public void RaiseEventDrag(Vector2 input)
        {
            OnDrag?.Invoke(input);
        }

    }
}