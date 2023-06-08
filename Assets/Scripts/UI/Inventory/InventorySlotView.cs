using OOP.ItemSystem.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private Image _slotIcon;
        [SerializeField] private TMP_Text _slotName;
        [SerializeField] private TMP_Text _slotDescription;

        public void SetModel(Item item)
        {
            _slotIcon.sprite = item.Icon;
            _slotName.SetText(item.Name);
            _slotDescription.SetText(item.Description);
        }
    }
}