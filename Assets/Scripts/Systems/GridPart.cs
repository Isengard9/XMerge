using UnityEngine;

namespace Game.General.Systems
{
    public class GridPart : MonoBehaviour
    {
        private bool isFull = false;
        public bool IsFull => isFull;

        [SerializeField]
        private GameObject xSign;

        public void SetFull(bool value = true)
        {
            isFull = value;
            xSign.SetActive(value);
        }
        
    }
}