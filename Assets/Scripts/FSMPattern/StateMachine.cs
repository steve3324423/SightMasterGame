using System;
using System.Collections.Generic;

namespace SightMaster.Scripts.FSM
{
    public class StateMachine
    {
        private Dictionary<string, FSMState> _statesById = new Dictionary<string, FSMState>();
        private Dictionary<Type, FSMState> _statesByType = new Dictionary<Type, FSMState>();
        private FSMState _currentState;

        public void AddState(string stateId, FSMState state)
        {
            _statesById[stateId] = state;
            _statesByType[state.GetType()] = state;
        }

        public void SetState(string stateId)
        {
            if (string.IsNullOrEmpty(stateId))
                return;

            if (_statesById.TryGetValue(stateId, out var newState))
            {
                if (_currentState != null && _currentState == newState)
                    return;

                _currentState?.Exit();
                _currentState = newState;
                _currentState.Enter();
            }
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}