using HFSM.StateMachine;
using UnityEngine;

namespace OOP.PlayerSystem.PlayerController.States
{
    public class StunState : State<PlayerStateMachine>
    {
        public StunState(PlayerStateMachine fsm) : base(fsm) { }

        public override void EnterState()
        {
            stateMachine.PlayerBody.velocity = Vector2.zero;
            stateMachine.OnInputsActiveChanged += CheckStateTransition;
        }

        public override void ExitState()
        {
            stateMachine.OnInputsActiveChanged += CheckStateTransition;
        }

        private void CheckStateTransition(bool canTransition)
        {
            if(canTransition)
                SetState<IdleState>();
        }
    }
}