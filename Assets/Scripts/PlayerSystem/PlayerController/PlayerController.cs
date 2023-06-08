using System;
using System.Collections.Generic;
using OOP.ItemSystem.Inventory;
using OOP.ItemSystem.Items;
using OOP.PlayerController.Item;
using UnityEngine;

namespace OOP.PlayerSystem.PlayerController
{
    public class PlayerController : MonoBehaviour, ICollector
    {
        public static event Action<bool, IReadOnlyList<Item>> OnInventoryStateChanged = delegate {  }; 
        private Inventory PlayerInventory { get; } = new Inventory();

        [SerializeField] private PlayerStateMachine _playerStateMachine;
        
        private readonly PlayerInputs _playerInputs = new PlayerInputs();
        private bool _inventoryIsActive;

        private void Awake()
        {
            _playerStateMachine.SetInput(_playerInputs);
        }

        private void OnEnable()
        {
            _playerInputs.OnInventoryInputPressed += ToggleInventory;
        }

        private void OnDisable()
        {
            _playerInputs.OnInventoryInputPressed -= ToggleInventory;
        }

        private void Update()
        {
            _playerInputs.UpdateInputs();
        }
        
        private void ToggleInventory()
        {
            _inventoryIsActive = !_inventoryIsActive;
            _playerStateMachine.SetInputsActive(!_inventoryIsActive);
            OnInventoryStateChanged(_inventoryIsActive, PlayerInventory.Slots);
        }

        public void Collect(Item item)
        {
            PlayerInventory.AddItem(item);
        }
    }
}