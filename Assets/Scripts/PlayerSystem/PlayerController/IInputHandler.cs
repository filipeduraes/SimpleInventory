using System;
using UnityEngine;

namespace OOP.PlayerSystem.PlayerController
{
    public interface IInputHandler
    {
        event Action OnAxisInputPressed;
        event Action OnInventoryInputPressed;
        
        Vector2 GetAxisInput();
        bool IsPressingAxis();
    }
}