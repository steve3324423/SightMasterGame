using System;
using System.Collections.Generic;

public class FSM 
{
    private Dictionary<Type,FSMState> _states = new Dictionary<Type,FSMState>();

    private FSMState StateCurrent { get; set; }

    public void AddState(FSMState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FSMState
    {
        var type = typeof(T);

        if (StateCurrent != null && StateCurrent.GetType() == type)
            return;

        if(_states.TryGetValue(type,out var newState))
        {
            StateCurrent?.Exit();
            StateCurrent = newState;
            StateCurrent.Enter();
        }
    }

    public void Update()
    {
        StateCurrent?.Update();
    }
}
