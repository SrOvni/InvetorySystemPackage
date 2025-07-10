using System;
using NUnit.Framework;
using UnityEngine;

namespace RG.InvetorySystem
{
    public class InvetorySlot
    {
        public ItemBase Item { get; set; }
        public int Quantity { get; set; }
        public bool IsEmpty => Item == null;

        public bool CanStack(ItemBase item)
        {
            return !IsEmpty && Item == item && Item.isStackable && Quantity < Item.maxStackSize;
        }

        public bool AddItem(ItemBase item, int amount = 1)
        {
            if (IsEmpty)
            {
                Item = item;
                Quantity = Mathf.Clamp(amount, 0, item.maxStackSize);
                return true;
            }
            else if (CanStack(item))
            {
                Quantity = Mathf.Clamp(Quantity + amount, 0, item.maxStackSize);
                return true;
            }
            return false;

        }

        public void RemoveItem(int amount)
        {
            if (IsEmpty) return;
            Quantity = Mathf.Clamp(Quantity - amount, 0, Item.maxStackSize);
            if (Quantity == 0) ClearSlot();
        }

        public void ClearSlot()
        {
            Item = null;
            Quantity = 0;
        }
    }
}