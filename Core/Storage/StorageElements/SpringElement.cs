using UnityEngine;

namespace Assets.Scripts.Core.Storage.StorageElements
{
    public class SpringElement : StorageElement
    {
        [field: Header("Spring Properties")]
        [field: SerializeField] public float Heigth { get; private set; }
        [field: SerializeField] public float Elasticity { get; private set; }
        [field: SerializeField] public bool ImmutableHeigth { get; private set; }
    }
}
