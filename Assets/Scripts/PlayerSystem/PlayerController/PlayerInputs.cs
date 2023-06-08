using System;
using UnityEngine;

namespace OOP.PlayerSystem.PlayerController
{
    public class PlayerInputs : IInputHandler
    {
        public event Action OnAxisInputPressed = delegate {  };
        public event Action OnInventoryInputPressed = delegate {  };

        private bool _isPressingAxis;
        private Vector2 _axisInput;

        public void UpdateInputs()
        {
            UpdateInventoryInput();
            UpdateAxisInput();
            UpdateIsPressingAxis();
        }

        private void UpdateInventoryInput()
        {
            if (Input.GetKeyDown(KeyCode.E))
                OnInventoryInputPressed();
        }

        public Vector2 GetAxisInput()
        {
            return _axisInput;
        }

        public bool IsPressingAxis()
        {
            return _isPressingAxis;
        }
        
        private void UpdateAxisInput()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            _axisInput = new Vector2(x, y);
        }
        
        private void UpdateIsPressingAxis()
        {
            bool wasPressingAxis = _isPressingAxis;
            _isPressingAxis = _axisInput.sqrMagnitude > 0f;

            if (wasPressingAxis != _isPressingAxis)
                OnAxisInputPressed();
        }
    }
}