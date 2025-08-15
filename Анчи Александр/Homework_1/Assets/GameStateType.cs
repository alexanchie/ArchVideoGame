using System.Collections.Generic;
using UnityEngine;

namespace Homework_1
{

    public enum GameStateType
    {
        MainMenu,
        GamePlay,
        Pause
    }

    public interface IGameState
    {
        void EnterState();
        void ExitState();
        void UpdateState();
    }

    public interface IUIService
    {
        void ShowMainMenu();
        void ShowGameplay();
        void ShowPause();
    }

    public sealed class CanvasUIService : IUIService
    {
        private readonly GameObject _mainMenu;
        private readonly GameObject _gameplay;
        private readonly GameObject _pause;

        public CanvasUIService(GameObject mainMenu, GameObject gameplay, GameObject pause)
        {
            _mainMenu = mainMenu;
            _gameplay = gameplay;
            _pause = pause;
        }

        public void ShowMainMenu()
        {
            SetActive(_mainMenu, true);
            SetActive(_gameplay, false);
            SetActive(_pause, false);
        }

        public void ShowGameplay()
        {
            SetActive(_mainMenu, false);
            SetActive(_gameplay, true);
            SetActive(_pause, false);
        }

        public void ShowPause()
        {
            SetActive(_mainMenu, false);
            SetActive(_gameplay, false);
            SetActive(_pause, true);
        }

        private static void SetActive(GameObject go, bool value)
        {
            if (go != null && go.activeSelf != value)
                go.SetActive(value);
        }
    }
}