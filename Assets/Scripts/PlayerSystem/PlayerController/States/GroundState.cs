using HFSM.StateMachine;

namespace OOP.PlayerSystem.PlayerController.States
{
    public class GroundState : State<PlayerStateMachine>
    {
        public GroundState(PlayerStateMachine fsm) : base(fsm) { }

        public override void EnterState()
        {
            stateMachine.OnInputsActiveChanged += CheckStunState;
        }

        public override void ExitState()
        {
            stateMachine.OnInputsActiveChanged -= CheckStunState;
        }

        private void CheckStunState(bool isActive)
        {
            if(!isActive)
                SetState<StunState>();
        }
    }
}