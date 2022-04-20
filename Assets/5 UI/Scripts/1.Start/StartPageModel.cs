using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame.UI
{
    public class StartPageModel : PageModelBase
    {

        public void SetLevel(int levelNum)
        {
            TitleText = "Level " + levelNum.ToString();
        }
        public void SetLevel(string levelTitle)
        {
            TitleText = levelTitle;
        }

    }
}