using Assets.Scripts.Core.Storage.StorageElements;
using UnityEngine;

namespace Assets.Scripts.Core.Storage.DynamicElements
{
    public class DynamicSpring : DynamicElement
    {
        public int wheel;
        public float heigth;
        public float elasticity;

        public DynamicSpring(int wheel, float heigth, float elasticity, StorageElement data, Material currentMaterial, int myId, int ownerId = -1) : base(data, currentMaterial, myId, ownerId)
        {
            this.wheel = wheel;
            this.heigth = heigth;
            this.elasticity = elasticity;
        }
    }
}
