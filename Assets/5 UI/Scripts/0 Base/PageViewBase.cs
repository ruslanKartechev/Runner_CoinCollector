using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
namespace CommonGame.UI
{
    public abstract class PageViewBase : MonoBehaviour
    {
        public Canvas myCanvas;
        [Space(10)]
        public Animator mAnim;
        public TextMeshProUGUI Title;
        public GameObject Header;
        public GameObject Footer;
        [Space(10)]
        public Button _Button;
        public TextMeshProUGUI ButtonText;


        public abstract void ShowPage();
        public abstract void HidePage();
        public abstract void ShowButton();
        public abstract void HideButton();
        public abstract void SetTitle(string text);
        public abstract void SetButtonText(string text);
        public abstract void CheckComponents();
        public abstract void SetButtonAction(UnityAction btnAction);
        public abstract void Init(object model);
        public abstract void UpdateView();

    }

    
}