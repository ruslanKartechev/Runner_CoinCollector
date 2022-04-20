using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CommonGame.UI
{
    public class LevelEndPageView : PageViewBase
    {
        private LevelEndPageModel _model;
        public override void Init(object model)
        {
            _model = (LevelEndPageModel)model;
        }
        public override void CheckComponents()
        {

        }
        public override void UpdateView()
        {
            SetButtonAction(_model.btnAction);
            SetButtonText(_model.ButtonText);
            SetTitle(_model.TitleText) ;
        }

        public override void ShowButton()
        {
            _Button.gameObject.SetActive(true);
        }
        public override void HideButton()
        {
            _Button.gameObject.SetActive(false);
        }

        public override void ShowPage()
        {
            mAnim.enabled = true;
            myCanvas.enabled = true;
            mAnim.Play("ShowPage", 0, 0);
            mAnim.Play("ShowButton", 1, 0);
        }
        public override void HidePage()
        {
            myCanvas.enabled = false;
            mAnim.enabled = false;
        }
        public void OnPageShown() { }
        public void OnPageHidden() { }
        public override void SetButtonAction(UnityAction btnAction)
        {
            _Button.onClick.RemoveAllListeners();
            _Button.onClick.AddListener(btnAction);
        }

        public override void SetButtonText(string text)
        {
            ButtonText.text = text;
        }

        public override void SetTitle(string text)
        {
            Title.text = text.ToString();
        }

    }
}