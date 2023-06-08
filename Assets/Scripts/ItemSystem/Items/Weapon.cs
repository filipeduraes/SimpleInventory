using UnityEngine;

namespace OOP.ItemSystem.Items
{
    [CreateAssetMenu(menuName = "OOP/Items/Weapon", fileName = "Weapon")]
    public class Weapon : Item
    {
        [Header("Weapon Settings")]
        [SerializeField] private int _damageDealt;
        [SerializeField] private int _durability;

        public int DamageDealt => _damageDealt;
        public int Durability => _durability;
    }
}