using System.Collections.Generic;
using OOP.ItemSystem.Items;
using OOP.PlayerSystem.PlayerController;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryUIPresenter : MonoBehaviour
    {
        [SerializeField] private InventoryUIView _view;
        
        private void OnEnable()
        {
            _view.gameObject.SetActive(false);
            PlayerController.OnInventoryStateChanged += SetInventoryActive;
        }

        private void OnDisable()
        {
            PlayerController.OnInventoryStateChanged -= SetInventoryActive;
        }

        private void SetInventoryActive(bool active, IReadOnlyList<Item> items)
        {
            _view.gameObject.SetActive(active);
            _view.SetModel(items);
        }
    }
}