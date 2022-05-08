using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;

namespace RunnerGame
{
    public class LevelProgressController : MonoBehaviour
    {
        [SerializeField] private ProgressManagerBase _progManager;

        private void Start()
        {
            if(_progManager == null) { _progManager = GetComponent<ProgressManagerBase>(); }
            _progManager.InitNewLevel();
           // GameManager.Instance._ui.progressPage.SetLevelProgress(0);
        }

        private void Update()
        {
            float prog = _progManager.CheckProgress();
          //  GameManager.Instance._ui.progressPage.SetLevelProgress(prog);
        }

    }



}