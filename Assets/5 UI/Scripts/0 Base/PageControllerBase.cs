using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
namespace CommonGame.UI
{
    public abstract class PageControllerBase : MonoBehaviour
    {
        public abstract void ShowPanel();

        public abstract void HidePanel();

        public abstract void SetButtonAction(UnityAction btnAction);

    }
}