using System;
using UnityEngine;

namespace Game.General.Managers
{
    public class CameraManager : Manager
    {

        #region Init

        public void InitCamera(float zValue, float size)
        {
            var pos = Camera.main.transform.position;
            pos.z = zValue;

            Camera.main.transform.position = pos;

            Camera.main.orthographicSize = size;
        }

        #endregion
        
        #region On Game Started Ended Paused

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