using Assets.Scripts.Core.Storage.StorageElements;
using UnityEngine;

namespace Assets.Scripts.Core.Storage.DynamicElements
{
    public class DynamicDoor : DynamicElement
    {
        public int glassId;
        public int mirrorId;

        public DynamicDoor(int glassId, int mirrorId, StorageElement data, Material currentMaterial, int myId, int ownerId = -1) : base(data, currentMaterial, myId, ownerId)
        {
            this.glassId = glassId;
            this.mirrorId = mirrorId;
        }
    }
}
