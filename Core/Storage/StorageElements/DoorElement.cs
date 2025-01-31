using UnityEngine;

namespace Assets.Scripts.Core.Storage.StorageElements
{
    [CreateAssetMenu(fileName = "Door", menuName = "Scriptables/Storage/Elements/Door")]
    public class DoorElement : StorageElement
    {
        [field: SerializeField] public StorageElement DefaultGlass { get; private set; }
        [field: SerializeField] public StorageElement DefaultMirror { get; private set; }
    }
}
