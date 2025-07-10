namespace RG.InvetorySystem
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class InvetoryManager : MonoBehaviour
    {
        [SerializeField] private int baseSlotCount = 10;
        private List<InvetorySlot> slots = new List<InvetorySlot>();

        public int CurrentSlotCount => slots.Count;

        private void Awake()
        {
            for (int i = 0; i < baseSlotCount; i++)
            {
                slots.Add(new InvetorySlot());
            }
        }

        public bool AddItem(ItemBase item, int amount = 1)
        {
            //Apilar item
            foreach (var slot in slots)
            {
                if (slot.CanStack(item))
                {
                    slot.AddItem(item, amount);
                    return true;
                }
            }
            //
            foreach (var slot in slots)
            {
                if (slot.IsEmpty)
                {
                    slot.AddItem(item, amount);
                    return true;
                }
            }
            Debug.Log("Inventario lleno");
            return false;
        }

        public void AddSlot(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                slots.Add(new InvetorySlot());
            }
        }

        public void RemoveSlot(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                
            }
        }
    }
}