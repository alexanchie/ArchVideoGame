using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    // ���������
    public IGameState MainMenuState { get; private set; }
    public IGameState GamePlayState { get; private set; }
    public IGameState PauseState { get; private set; }

    private IGameState _currentState;

    private void Awake()
    {
        // Singleton �������
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // ����� �� ����������� ��� �������� ����

        // �������������� ���������
        MainMenuState = new MainMenuState();
        GamePlayState = new GamePlayState();
        PauseState = new PauseState();
    }

    private void Start()
    {
        // �������� � �������� ����
        ChangeState(MainMenuState);
    }

    private void Update()
    {
        _currentState?.UpdateState();
    }
    public void ResumeFromPause()
    {
        ChangeState(GamePlayState); // ������������ � ������� �����
    }
    // ����� ��� ����� ���������
    public void ChangeState(IGameState newState)
    {
        _currentState?.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }
    public void PauseGame()
    {
        Debug.Log("PauseGame()");
        ChangeState(PauseState);
    }
    // ������ ��� �������� ������������
    public void GoToMainMenu() => ChangeState(MainMenuState);
    public void StartGame() => ChangeState(GamePlayState);
  
    public void ResumeGame() => ChangeState(GamePlayState);
}
