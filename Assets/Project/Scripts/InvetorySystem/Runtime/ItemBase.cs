using UnityEngine;

namespace RG.InvetorySystem
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "ItemBase", menuName = "Invetory Item base", order = 0)]
    public abstract class ItemBase : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public bool isStackable;
        public int maxStackSize = 1;
    }
}
