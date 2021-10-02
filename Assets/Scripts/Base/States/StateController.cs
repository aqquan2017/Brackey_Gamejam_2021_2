﻿using System;
using System.Collections.Generic;

/// <summary>
/// Controller of transitions between States
/// </summary>
public class StateController
{
    /// <summary>
    /// Current active State
    /// </summary>
    public IState CurrentState
    {
        get
        {
            return m_CurrentState;
        }
    }

    private IState m_CurrentState;
    private Dictionary<Type, IState> m_States;

    public StateController(Dictionary<Type, IState> states)
    {
        m_States = states;
    }

    public void SetState<T>() where T : IState
    {
        if (m_CurrentState != null)
            m_CurrentState.Exit();

        m_CurrentState = m_States[typeof(T)];
        m_CurrentState.Enter();
    }

    public T GetState<T>() where T : class, IState
    {
        if (m_States.ContainsKey(typeof(T)))
        {
            return m_States[typeof(T)] as T;
        }
        else
        {
            throw new KeyNotFoundException("State is not found");
        }
    }
}
