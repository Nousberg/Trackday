using Assets.Scripts.Core.Storage.StorageElements;
using UnityEngine;

namespace Assets.Scripts.Core.Storage.DynamicElements
{
    public class DynamicElement
    {
        public readonly StorageElement data;
        public Material currentMaterial;
        public int myId;
        public int ownerId;

        public DynamicElement(StorageElement data, Material currentMaterial, int myId, int ownerId = -1)
        {
            this.data = data;
            this.currentMaterial = new Material(currentMaterial);
            this.myId = myId;
            this.ownerId = ownerId;
        }
    }
}
