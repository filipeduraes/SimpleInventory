using System;
using HFSM.StateMachine;
using UnityEngine;

namespace OOP.PlayerSystem.PlayerController.States
{
    public class IdleState : State<PlayerStateMachine>
    {
        public IdleState(PlayerStateMachine fsm) : base(fsm) { }

        public override Type ParentState => typeof(GroundState);

        public override void EnterState()
        {
            stateMachine.PlayerBody.velocity = Vector2.zero;
            stateMachine.InputHandler.OnAxisInputPressed += TransitionToWalk;
        }

        public override void ExitState()
        {
            stateMachine.InputHandler.OnAxisInputPressed -= TransitionToWalk;
        }

        private void TransitionToWalk()
        {
            SetState<WalkState>();
        }
    }
}