using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CommonGame.UI
{
    public class GameUIController : MonoBehaviour
    {
        public StartPageController startPage;
        public ProgressPageController progressPage;
        public LevelEndPageController levelEndPage;

        public GameObject MainCanvas;
        public void Init()
        {
            if (startPage == null) { startPage = FindObjectOfType<StartPageController>(); }
            if (progressPage == null) { progressPage = FindObjectOfType<ProgressPageController>(); }
            if (levelEndPage == null) { levelEndPage = FindObjectOfType<LevelEndPageController>(); }
            GameManager.Instance._events.LevelLoaded.AddListener(OnLevelLoaded);
            GameManager.Instance._events.LevelStarted.AddListener(OnLevelStart);
            GameManager.Instance._events.LevelEndReached.AddListener(OnLevelFinishReached);
            GameManager.Instance._events.PlayerWin.AddListener(OnPlayerWin);
            GameManager.Instance._events.PlayerLose.AddListener(OnPlayerLoose);
            levelEndPage.HidePanel();
            startPage.HidePanel();
            progressPage.HidePanel();
        }

        public void OnLevelLoaded()
        {
            progressPage.HidePanel();
            levelEndPage.HidePanel();
            startPage.ShowPanel();
        }
        public void OnLevelStart()
        {
            progressPage?.ShowPanel();
        }
        public void OnPlayerLoose()
        {
            levelEndPage.OnLoose();
            levelEndPage.ShowPanel();
        }
        public void OnPlayerWin()
        {
            levelEndPage.OnWin();
            levelEndPage.ShowPanel();
        }
        public void OnLevelFinishReached()
        {
            progressPage.HidePanel();
        }

    }
}