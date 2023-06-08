using System;
using HFSM.StateMachine;
using OOP.PlayerSystem.PlayerController.States;
using UnityEngine;

namespace OOP.PlayerSystem.PlayerController
{
    public class PlayerStateMachine : StateMachine<PlayerStateMachine>
    {
        public event Action<bool> OnInputsActiveChanged = delegate {  };
        
        public IInputHandler InputHandler { get; private set; }
        public Rigidbody2D PlayerBody => _playerBody;
        public float PlayerVelocity => _playerVelocity;

        [SerializeField] private Rigidbody2D _playerBody;
        [SerializeField] private float _playerVelocity;

        protected override void SetInitialState()
        {
            SetState<IdleState>();
        }

        public void SetInput(IInputHandler inputHandler)
        {
            InputHandler = inputHandler;
        }

        public void SetInputsActive(bool active)
        {
            OnInputsActiveChanged(active);
        }
    }
}
