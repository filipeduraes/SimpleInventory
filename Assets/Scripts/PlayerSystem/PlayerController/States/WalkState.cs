using System;
using HFSM.StateMachine;
using UnityEngine;

namespace OOP.PlayerSystem.PlayerController.States
{
    public class WalkState : State<PlayerStateMachine>
    {
        public WalkState(PlayerStateMachine fsm) : base(fsm) { }

        public override Type ParentState => typeof(GroundState);

        public override void FixedUpdate()
        {
            if (!stateMachine.InputHandler.IsPressingAxis())
            {
                SetState<IdleState>();
                return;
            }

            Vector2 velocity = GetCurrentVelocity();
            stateMachine.PlayerBody.velocity = velocity;
        }

        private Vector2 GetCurrentVelocity()
        {
            float xVelocity = stateMachine.InputHandler.GetAxisInput().x * stateMachine.PlayerVelocity;
            Vector2 velocity = new Vector2(xVelocity, stateMachine.PlayerBody.velocity.y);
            return velocity;
        }
    }
}