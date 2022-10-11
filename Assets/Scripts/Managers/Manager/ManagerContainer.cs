using System;
using UnityEngine;

namespace Game.General.Managers
{
    public class ManagerContainer : MonoBehaviour
    {
        private static ManagerContainer instance;
        public static ManagerContainer Instance => instance;

        [SerializeField]
        private UIManager uiManager;
        public UIManager UIManager => uiManager;

        [SerializeField]
        private GameManager gameManager;
        public GameManager GameManager => gameManager;
        
        private void Awake()
        {
            instance = this;
        }

        private void OnDestroy()
        {
            
        }
    }
}