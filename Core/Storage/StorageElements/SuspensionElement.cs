using UnityEngine;

namespace Assets.Scripts.Core.Storage.StorageElements
{
    internal class SuspensionElement : StorageElement
    {
        [field: Header("Suspension Properties")]
        [field: SerializeField] public float DefaultWheelDistance { get; private set; }
        [field: SerializeField] public float DefaultWheelAngle { get; private set; }
    }
}
