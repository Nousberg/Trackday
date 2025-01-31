using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Storage.StorageElements
{
    [CreateAssetMenu(fileName = "Vehicle", menuName = "Scriptables/Storage/Elements/Vehicle")]
    public class VehicleElement : StorageElement
    {
        [field: Header("Vehicle Properties")]
        [field: SerializeField] public int MaxWheels { get; private set; }
        [field: SerializeField] public int MaxLeftDoors { get; private set; }
        [field: SerializeField] public int MaxRigthDoors { get; private set; }
        [field: SerializeField] public List<ElementCategory> CustomizableElements { get; private set; } = new List<ElementCategory>();
        [field: SerializeField] public List<StorageElement> SupportedElements { get; private set; } = new List<StorageElement>();
        [field: SerializeField] public List<StorageElement> BaseElements { get; private set; } = new List<StorageElement>();
    }
}
