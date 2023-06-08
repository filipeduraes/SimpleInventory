using System;
using UnityEngine;

namespace OOP.PlayerController.Item
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private ItemSystem.Items.Item _itemToCollect;
        [SerializeField] private SpriteRenderer _icon;

        private void Awake()
        {
            UpdateIcon();
        }

        private void OnValidate()
        {
            UpdateIcon();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ICollector collector))
            {
                collector.Collect(_itemToCollect);
                Destroy(gameObject);
            }
        }
        
        private void UpdateIcon()
        {
            Sprite icon = null;

            if (_itemToCollect != null)
                icon = _itemToCollect.Icon;

            _icon.sprite = icon;
        }
    }
}
