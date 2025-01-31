using Assets.Scripts.Core.Storage.StorageElements;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Storage.DynamicElements
{
    internal class DynamicVehicle : DynamicElement
    {
        public List<int> elements = new List<int>();

        public DynamicVehicle(List<int> elements, StorageElement data, Material currentMaterial, int myId, int ownerId = -1) : base(data, currentMaterial, myId, ownerId)
        {
            this.elements = elements;
        }
    }
}
