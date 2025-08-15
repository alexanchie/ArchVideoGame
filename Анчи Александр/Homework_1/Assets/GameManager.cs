using Homework_1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Bootstrap();
    }

    [Header("UI Panels/Canvases")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject pausePanel;


    private readonly Dictionary<GameStateType, IGameState> _states = new Dictionary<GameStateType, IGameState>();
    private IGameState _currentState;
    private GameStateType _currentType;
    private IUIService _uiService;

    private void Bootstrap()
    {
        _uiService = new CanvasUIService(mainMenuPanel, gameplayPanel, pausePanel);

        _states[GameStateType.MainMenu] = new MainMenuState(this, _uiService);
        _states[GameStateType.GamePlay] = new GamePlayState(this, _uiService);
        _states[GameStateType.Pause] = new PauseState(this, _uiService);

        SwitchState(GameStateType.MainMenu);
    }


 
    public void SwitchState(GameStateType target)
    {
        if (_currentState != null)
            _currentState.ExitState();

        _currentState = _states[target];
        _currentType = target;
        _currentState.EnterState();
    }

    public void OnPlayPressed() => SwitchState(GameStateType.GamePlay);
    public void OnPausePressed() => SwitchState(GameStateType.Pause);
    public void OnResumePressed() => SwitchState(GameStateType.GamePlay);
    public void OnMenuPressed() => SwitchState(GameStateType.MainMenu);

    public void OnExitPressed()
    {
        
        Application.Quit();

     
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}


