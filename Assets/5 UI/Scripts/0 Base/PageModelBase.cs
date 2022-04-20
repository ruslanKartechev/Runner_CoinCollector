using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
namespace CommonGame.UI
{
    public class PageModelBase : MonoBehaviour
    {
        public string TitleText;
        public string ButtonText;
        public float ProgressValue;
        public UnityAction btnAction;
        
    }
}