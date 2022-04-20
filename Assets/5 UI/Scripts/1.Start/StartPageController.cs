using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace CommonGame.UI
{
    public class StartPageController : PageControllerBase
    {
        public StartPageModel _model;
        public PageViewBase _view;
        private void Start()
        {
            _model.btnAction = CallLevelStart;
            _view.Init(_model);
        }
        public override void ShowPanel()
        {
            _model.SetLevel(GameManager.Instance.levelManager.CurrentLevelIndex+1);
            _view.ShowPage();
        }
        public override void HidePanel()
        {
            _view.HidePage();
        }

        public override void SetButtonAction(UnityAction btnAction)
        {
            _view.SetButtonAction(btnAction);
        }
        public void CallLevelStart()
        {
            _view.HidePage();
            GameManager.Instance._events.LevelStarted.Invoke();
        }

    }
}