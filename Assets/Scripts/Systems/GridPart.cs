using System;
using System.Collections.Generic;
using Game.General.Managers;
using UnityEngine;

namespace Game.General.Systems
{
    public class GridPart : MonoBehaviour
    {
        private bool isFull = false;
        public bool IsFull => isFull;

        [SerializeField] private GameObject xSign;

        public int PositionX = 0;
        public int PositionY = 0;

        [SerializeField] private int gridWeight;
        public int GridWeight => gridWeight;

        [SerializeField] private List<GridPart> connectedParts = new List<GridPart>();
        public List<GridPart> ConnectedParts => connectedParts;

        public void InitGridPart(Vector2 position)
        {
            PositionX = (int)position.x;
            PositionY = (int)position.y;
        }

        public void AddConnectedPart(GridPart part)
        {
            if (!connectedParts.Contains(part))
            {
                connectedParts.Add(part);

                for (int i = 0; i < connectedParts.Count; i++)
                {
                    connectedParts[i].AddConnectedPart(part);
                }
            }


            gridWeight = connectedParts.Count;
        }

        void GetConnectedParts()
        {
            for (int i = 0; i < connectedParts.Count; i++)
            {
                for (int j = 0; j < connectedParts[i].ConnectedParts.Count; j++)
                {
                    AddConnectedPart(connectedParts[i].ConnectedParts[j]);
                }
            }
        }

        private void ControlSides()
        {
            var part = ManagerContainer.Instance.GridManager.GridParts.Find(x =>
                x.PositionX == PositionX - 1 && x.PositionY == PositionY && x.isFull);

            if (part is not null)
            {
                connectedParts.Add(part);
            }

            part = ManagerContainer.Instance.GridManager.GridParts.Find(x =>
                x.PositionX == PositionX + 1 && x.PositionY == PositionY && x.isFull);

            if (part is not null)
            {
                connectedParts.Add(part);
            }

            part = ManagerContainer.Instance.GridManager.GridParts.Find(x =>
                x.PositionY == PositionY - 1 && x.PositionX == PositionX && x.isFull);

            if (part is not null)
            {
                connectedParts.Add(part);
            }

            part = ManagerContainer.Instance.GridManager.GridParts.Find(x =>
                x.PositionY == PositionY + 1 && x.PositionX == PositionX && x.isFull);

            if (part is not null)
            {
                connectedParts.Add(part);
            }

            connectedParts.Add(this);

            for (int i = 0; i < connectedParts.Count; i++)
            {
                connectedParts[i].AddConnectedPart(this);
            }

            GetConnectedParts();
            
            ControlGridWeight();
        }

        private void ControlGridWeight()
        {
            if (gridWeight >= 3)
            {
                foreach (var connectedPart in connectedParts)
                {
                    connectedPart.SetFull(false);
                }
            }
        }

        public void SetFull(bool value = true)
        {
            isFull = value;
            xSign.SetActive(value);

            if (value)
            {
                connectedParts.Clear();
                ControlSides();
            }
            
        }
    }
}