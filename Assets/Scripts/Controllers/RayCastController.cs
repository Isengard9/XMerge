using System;
using Game.General.Systems;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class RayCastController : MonoBehaviour
    {
        private RaycastHit hit;

        [SerializeField] private LayerMask gridMask;


        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                RayToGrid();
            }
        }

        #region Control Check Grid Hitted

        private void RayToGrid()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, gridMask))
            {
                var gridPart = hit.transform.GetComponent<GridPart>();
                gridPart.SetFull();
            }
        }

        #endregion
    }
}

