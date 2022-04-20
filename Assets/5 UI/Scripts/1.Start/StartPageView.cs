using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace CommonGame.UI
{
    public class StartPageView : PageViewBase
    {
        [SerializeField] private StartPageModel _model;
        public Action OnShown;
        public Action OnHidden;
        public override void Init(object model)
        {
            _model = (StartPageModel)model;
            CheckComponents();
            SetTitle(_model.TitleText);
            if (_model.btnAction != null)
                SetButtonAction(_model.btnAction);
            else
                Debug.Log("Null button Action");
        }
        public override void UpdateView()
        {
            SetButtonAction(_model.btnAction);
            SetButtonText(_model.ButtonText);
            SetTitle(_model.TitleText);
        }
        public override void CheckComponents()
        {
            if(mAnim == null) { DebugMissing("Animator not assigned"); }
            if (Title == null) { DebugMissing("Title text not assigned"); }
            if (_Button == null) { DebugMissing("Button not assigned"); }

            void DebugMissing(string text)
            {
                Debug.Log("<color=red> " + text + " </color>");
            }
        }
        public override void ShowPage()
        {
            myCanvas.enabled = true;
            mAnim.enabled = true;
            SetTitle(_model.TitleText); 
            mAnim.Play("ShowPage", 0,0);
            mAnim.Play("ShowButton", 1, 0);
        }
        public override void HidePage()
        {
            mAnim.Play("HidePage", 0, 0);
            mAnim.Play("HideButton", 1, 0);
        }
        public void OnPageShown()
        {
            OnShown?.Invoke();
        }
        public void OnPageHidden()
        {
            myCanvas.enabled = false;
            mAnim.enabled = false;
            OnHidden?.Invoke();
        }
        public override void SetTitle(string text)
        {
            Title.text = text;
        }

        #region Button
        public override void SetButtonAction(UnityAction btnAction)
        {
            _Button.onClick.RemoveAllListeners();
            _Button.onClick.AddListener(btnAction);
        }
        public override void ShowButton()
        {
            _Button.gameObject.SetActive(true);
        }
        public override void HideButton()
        {
            _Button.gameObject.SetActive(false);
        }
        public override void SetButtonText(string text)
        {
            ButtonText.text = text;
        }


        #endregion




    }
}