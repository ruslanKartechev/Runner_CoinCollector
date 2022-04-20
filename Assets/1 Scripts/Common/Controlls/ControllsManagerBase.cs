using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame.UI;
namespace CommonGame.Controlls
{
    
    public abstract class ControllsManagerBase : InputObservableBase
    {
        protected Coroutine InputCheck;
        protected abstract IEnumerator InputChecking();
        protected abstract void StartInputCheck();
        protected abstract void StopInputCheck();
        public abstract void Init(object ui);
        public abstract void EnableControlls();
        public abstract void DisableControlls();
        public abstract void ShowControlls();
        public abstract void HideControlls();
        protected abstract void OnClick();
        protected abstract void OnRelease();
    }
}
