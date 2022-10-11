using System;
using System.Collections.Generic;
using Game.General.Systems;
using UnityEngine;

namespace Game.General.Managers
{

    public enum GridLayout
    {
        _5x5 = 25,
        _7x7 = 49,
        _9x9 = 81,
    }
    
    public class GridManager : Manager
    {
        [SerializeField]
        private GridLayout layout;
        public GridLayout Layout => layout;

        [SerializeField]
        private List<GridPart> gridParts = new List<GridPart>();
        public List<GridPart> GridParts => gridParts;

        [SerializeField]
        private GameObject gridPartPrefab;

        [SerializeField] 
        private GameObject gridsParent;

        #region Create Grid

        private void CreateGrid()
        {
            gridsParent = new GameObject();
            var gridLineCount = Mathf.Sqrt((int)layout);
            var gridStartValue = (int)(gridLineCount / 2);
            for (int i = gridStartValue * -1; i < gridStartValue + 1; i++)
            {
                for (int j = gridStartValue * -1; j < gridStartValue + 1; j++)
                {
                    var gridPart = Instantiate(gridPartPrefab,gridsParent.transform);
                    gridPart.transform.position = new Vector3(i, 0, j);
                    gridParts.Add(gridPart.GetComponent<GridPart>());
                }
            }
            
            ManagerContainer.Instance.CameraManager.InitCamera(gridStartValue * -1,gridLineCount);
            
        }

        #endregion
        
        #region On Game Started Paused Ended Functions

        protected override void OnGameStarted()
        {
            CreateGrid();
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