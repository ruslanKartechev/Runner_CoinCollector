using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
namespace RunnerGame
{
    public class ScoreKeeperController : SingletonMB<ScoreKeeperController>
    {
        private CollectableRecorderBase coinsRecorder;
        private void Awake()
        {
            coinsRecorder = new CoinsRecorder();
        }
        public void OnCoinCollected()
        {
            coinsRecorder.Collect(1);
          //  GameManager.Instance._ui.progressPage.SetCoinCount(coinsRecorder.Collected);
        }
        public void Refresh()
        {
            coinsRecorder.Refresh();
        //    GameManager.Instance._ui.progressPage.SetCoinCount(coinsRecorder.Collected);
        }
    }
}