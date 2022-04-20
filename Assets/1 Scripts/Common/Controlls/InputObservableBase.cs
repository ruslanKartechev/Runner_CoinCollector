using System.Collections;
using UnityEngine;
using System;
namespace CommonGame.Controlls
{
    public delegate void Notification();
    public delegate void Movement(Vector2 input);

    public class InputObservableBase : MonoBehaviour
    {
        public event Notification Clicked;
        public event Notification Released;
        public event Movement MouseMove;

        protected virtual void ClearAllListeners()
        {
            foreach (Delegate d in Clicked.GetInvocationList())
            {
                Clicked -= (Notification)d;
            }
            foreach (Delegate d in Released.GetInvocationList())
            {
                Released -= (Notification)d;
            }
            foreach (Delegate d in MouseMove.GetInvocationList())
            {
                MouseMove -= (Movement)d;
            }
        }
        protected virtual void FireEvent(InputTypes type, object input)
        {
            switch (type)
            {
                case InputTypes.Click:
                    Clicked?.Invoke();
                    break;
                case InputTypes.Release:
                    Released?.Invoke();
                    break;
                case InputTypes.MouseMove:
                    Vector2 inp = (Vector2)input;
                    MouseMove?.Invoke(inp);
                    break;
            }
        }
    }
}