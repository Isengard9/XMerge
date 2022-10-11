using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.General.Managers
{
    public class UIManager : Manager
    {
        [SerializeField]
        private TMP_Dropdown layoutSetter;
        
        protected override void OnStart()
        {
            base.OnStart();
            layoutSetter.onValueChanged.AddListener(OnLayoutChanged);    
        }

        private void OnLayoutChanged(int arg0)
        {
            ManagerContainer.Instance.GridManager.SetLayout(arg0);
            ManagerContainer.Instance.GridManager.CreateGrid();
        }

        #region On Game Started/Paused/Ended

        protected override void OnGameStarted()
        {
        }

        protected override void OnGamePaused(bool obj)
        {
        }

        protected override void OnGameEnded(bool win)
        {
            
        }

        #endregion

        
    }
}