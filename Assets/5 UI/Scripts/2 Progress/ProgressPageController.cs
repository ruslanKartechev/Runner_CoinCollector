using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CommonGame.UI
{
    public class ProgressPageController : PageControllerBase
    {
        public ProgressPageModel _model;
        public PageViewBase _view;
        private void Start()
        {
            _view.Init(_model);
            _view.UpdateView();
        }
        public override void HidePanel()
        {
            _view.HidePage();
        }

        public override void SetButtonAction(UnityAction btnAction)
        {
            _view.SetButtonAction(btnAction);
        }

        public override void ShowPanel()
        {
            _view.ShowPage();
            _model.CurrentLevel = GameManager.Instance.levelManager.CurrentLevelIndex + 1;
        }
        public void SetCoinCount(int count)
        {
            _model.CoinsCount = count;
            _view.UpdateView();
        }
        public void SetLevelProgress(float progress)
        {
            progress = Mathf.Clamp01(progress);
            _model.ProgressValue = progress;
            _view.UpdateView();
            
        }

    }
}