using System;

using Game.General.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Game.General.Managers
{
    public class GameManager : Manager
    {

        #region Actions

        public Action GameStarted;
        public Action<bool> GameEnded;
        public Action<bool> GamePaused;

        #endregion

        #region Booleans

        private static bool isGameStarted = false;
        private static bool isGameEnded = false;
        private static bool isGamePaused = false;

        public bool IsGameStarted => isGameStarted;
        public bool IsGameEnded => IsGameEnded;
        public bool IsGamePaused => IsGamePaused;


        public bool IsGamePlayable => isGameStarted && !isGameEnded && !isGamePaused; 

        #endregion

        #region Game Functions

        protected override void OnGameStarted()
        {
            isGameStarted = true;
            isGameEnded = false;
            isGamePaused = false;
        }

        protected override void OnGameEnded(bool win)
        {
            isGameEnded = true;
        }

        protected override void OnGamePaused(bool state)
        {
            isGamePaused = state;
        }

        #endregion
        
        #region Start Game

        public static void StartGame()
        {
            isGameStarted = true;
            ManagerContainer.Instance.GameManager.GameStarted?.Invoke();
        }

        #endregion

        #region End Game

        public static void EndGame(bool win)
        {
            ManagerContainer.Instance.GameManager.GameEnded?.Invoke(win);
            
        }

        #endregion

        #region Pause Game

        public static void PauseGame(bool state)
        {
            ManagerContainer.Instance.GameManager.GamePaused?.Invoke(state);
        }

        #endregion

        #region Reset Game

        public void ResetGame()
        {
            isGameStarted = isGameEnded = isGamePaused = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        #endregion
    }
}
