using UnityEngine;

namespace OOP.ItemSystem.Items
{
    [CreateAssetMenu(menuName = "OOP/Items/Food", fileName = "New Food")]
    public class Food : Item
    {
        [Header("Food Settings")]
        [SerializeField, Range(0, 15)] private int _energyRestorationAmount;

        public int EnergyRestorationAmount => _energyRestorationAmount;
    }
}