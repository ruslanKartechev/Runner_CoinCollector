using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace CommonGame.UI
{
    public class LevelEndPageController : PageControllerBase
    {
        [SerializeField] private PageViewBase _view;
        [SerializeField] private LevelEndPageModel _model;
        private void Start()
        {
            _view.Init(_model);
            _model.btnAction = CallNextLevel;
        }
        public override void ShowPanel()
        {
            int level = GameManager.Instance.levelManager.CurrentLevelIndex+1;
            _model.TitleText = "Level " + level.ToString() + " Completed";
            _view.UpdateView();
            _view.ShowPage();
        }
        public override void HidePanel()
        {
            _view.HidePage();
        }
        public void OnWin()
        {
            _model.ButtonText = "Next";
            _model.btnAction = CallNextLevel;
        }
        public void OnLoose()
        {
            _model.ButtonText = "Retry";
            _model.btnAction = CallRestart;
        }
        public override void SetButtonAction(UnityAction btnAction)
        {
            _model.btnAction = btnAction;
        }

        public void CallNextLevel()
        {
            GameManager.Instance._events.NextLevelCalled.Invoke();
            GameManager.Instance.levelManager.NextLevel();
        }
        public void CallRestart()
        {
            GameManager.Instance._events.NextLevelCalled.Invoke();
            GameManager.Instance.levelManager.RestartLevel();
        }

    }
}