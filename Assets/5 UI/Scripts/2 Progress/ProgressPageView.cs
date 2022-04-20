using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
namespace CommonGame.UI
{
    public class ProgressPageView : PageViewBase
    {
        [Header("Coins")]
        [Space(10)]
        public GameObject _coinContainer;
        public TextMeshProUGUI _coinCountText;
        [Space(5)]
        public Transform ProgBarContainer;
        public Image ProgBarFill;
        [Space(5)]
        public TextMeshProUGUI LevelText;
        public ProgressPageModel _model;
        public override void ShowPage()
        {
            myCanvas.enabled = true ;
            _coinContainer.SetActive(true);
            CheckComponents();
        }

        public override void HidePage()
        {
            myCanvas.enabled = false;
        }

        public override void CheckComponents()
        {
            if (_model == null) { Debug.Log("model not assigned to view"); }
            if (_coinContainer == null) { Debug.Log("coins container not assigned"); }
            if(_coinCountText == null) { Debug.Log("coins text not assigned"); }
        }

        public override void UpdateView()
        {
            _coinCountText.text = _model.CoinsCount.ToString();
            ProgBarFill.fillAmount = _model.ProgressValue;
            LevelText.text = _model.CurrentLevel.ToString();
        }

        #region NotImpl
        public override void SetButtonAction(UnityAction btnAction)
        {
        }

        public override void SetButtonText(string text)
        {
        }

        public override void SetTitle(string text)
        {

        }

        public override void ShowButton()
        {

        }
        public override void HideButton()
        {
        }

        public override void Init(object model)
        {
        }
        #endregion

    }
}
