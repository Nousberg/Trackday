using Assets.Scripts.Core.Storage.StorageElements;
using UnityEngine;

namespace Assets.Scripts.Core.Storage.DynamicElements
{
    public class DynamicWheel : DynamicElement
    {
        public int slot;

        public DynamicWheel(int slot, StorageElement data, Material currentMaterial, int myId, int ownerId = -1) : base(data, currentMaterial, myId, ownerId)
        {
            this.slot = slot;
        }
    }
}
