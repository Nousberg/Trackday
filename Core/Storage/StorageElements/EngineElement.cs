using UnityEngine;

namespace Assets.Scripts.Core.Storage.StorageElements
{
    [CreateAssetMenu(fileName = "Engine", menuName = "Scriptables/Storage/Elements/Engine")]
    public class EngineElement : StorageElement
    {
        [field: Header("Engine Properties")]
        [field: SerializeField] public float HorsePower { get; private set; }
    }
}
