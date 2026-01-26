namespace SightMaster.Scripts.FSM
{
    public abstract class FSMState
    {
        protected readonly StateMachine StateMachine;

        public FSMState(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
