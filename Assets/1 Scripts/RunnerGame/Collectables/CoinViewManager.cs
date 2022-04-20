using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CoinViewManager : ViewManagerBase
    {
        public GameObject CoinModel;

        public override void Show()
        {
            CoinModel.SetActive(true);
        }
        public override void Hide()
        {
            CoinModel.SetActive(false);
        }

    }
}