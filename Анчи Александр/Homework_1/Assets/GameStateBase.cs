using Homework_1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateBase : IGameState
{
    protected readonly GameManager GM;
    protected readonly IUIService UI;

    protected GameStateBase(GameManager gm, IUIService ui)
    {
        GM = gm;
        UI = ui;
    }

    public abstract void EnterState();
    public abstract void ExitState();
    public virtual void UpdateState() { }
}

public sealed class MainMenuState : GameStateBase
{
    public MainMenuState(GameManager gm, IUIService ui) : base(gm, ui) { }

    public override void EnterState()
    {
        Time.timeScale = 1f;
        UI.ShowMainMenu();
    }

    public override void ExitState()
    {
        
    }
}

public sealed class GamePlayState : GameStateBase
{
    public GamePlayState(GameManager gm, IUIService ui) : base(gm, ui) { }

    public override void EnterState()
    {
        Time.timeScale = 1f;
        UI.ShowGameplay();
    }

    public override void ExitState()
    {
      
    }

    public override void UpdateState()
    {
     
    }
}

public sealed class PauseState : GameStateBase
{
    public PauseState(GameManager gm, IUIService ui) : base(gm, ui) { }

    public override void EnterState()
    {
        UI.ShowPause();
        Time.timeScale = 0f; 
    }

    public override void ExitState()
    {
        Time.timeScale = 1f;
    }
}
