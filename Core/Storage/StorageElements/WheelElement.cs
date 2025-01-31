using UnityEngine;

namespace Assets.Scripts.Core.Storage.StorageElements
{
    [CreateAssetMenu(fileName = "Wheel", menuName = "Scriptables/Storage/Elements/Wheel")]
    public class WheelElement : StorageElement
    {
        [field: Header("Wheel Properties")]
        [field: SerializeField] public float Friction { get; private set; }
        [field: SerializeField] public WheelSeason Season { get; private set; }

        public enum WheelSeason : byte
        {
            Summer,
            Winter
        }
    }
}
