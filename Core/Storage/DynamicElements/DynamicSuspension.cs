using Assets.Scripts.Core.Storage.StorageElements;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Storage.DynamicElements
{
    public class DynamicSuspension : DynamicElement
    {
        public List<int> springs = new List<int>();
        public float wheelsDistance;
        public float wheelsAngle;

        public DynamicSuspension(List<int> springs, float wheelsDistance, float wheelsAngle, StorageElement data, Material currentMaterial, int myId, int ownerId = -1) : base(data, currentMaterial, myId, ownerId)
        {
            this.wheelsDistance = wheelsDistance;
            this.wheelsAngle = wheelsAngle;
            this.springs = springs;
        }
    }
}
