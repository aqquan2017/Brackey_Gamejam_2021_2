using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Win1GameState : IState
{
    public event Action OnWinGame;
    ISceneManagement sceneManagement;

    public Win1GameState()
    {
        Services.Find(out sceneManagement);
    }

    public void Enter()
    {
        Debug.Log("WIN GAME");

        OnWinGame?.Invoke();
        SoundManager.Instance.Play(Sounds.WIN_LV);
        TimerManager.Instance.AddTimer(1f,()=> UIManager.Instance.ShowPanelWithDG(typeof(WinLvPanel)));
    }

    public void OnNexLv()
    {
        sceneManagement.NextScene();
    }

    public void Exit()
    {
        UIManager.Instance.HidePanelWithDG(typeof(WinLvPanel));
    }
}