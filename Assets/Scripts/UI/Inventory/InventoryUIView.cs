using System.Collections.Generic;
using OOP.ItemSystem.Items;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryUIView : MonoBehaviour
    {
        [SerializeField] private InventorySlotView _slotPrefab;
        [SerializeField] private Transform _slotsContainer;

        private readonly List<InventorySlotView> _spawnedSlots = new List<InventorySlotView>();

        public void SetModel(IReadOnlyList<Item> model)
        {
            int slotsToSpawn = model.Count - _spawnedSlots.Count;
            SpawnSlots(slotsToSpawn);

            for (int index = 0; index < _spawnedSlots.Count; index++)
            {
                InventorySlotView slot = _spawnedSlots[index];
                Item slotItem = model[index];
                
                slot.SetModel(slotItem);
            }
        }

        private void SpawnSlots(int slotsToSpawn)
        {
            for (int i = 0; i < slotsToSpawn; i++)
            {
                InventorySlotView newSlot = Instantiate(_slotPrefab, _slotsContainer);
                _spawnedSlots.Add(newSlot);
            }
        }
    }
}