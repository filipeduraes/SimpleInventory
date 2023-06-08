using UnityEngine;

namespace OOP.ItemSystem.Items
{
    public abstract class Item : ScriptableObject
    {
        [Header("Info")]
        [SerializeField] private string _name;
        [SerializeField, TextArea] private string _description;
        [SerializeField] private Sprite _icon;

        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;
    }
}
