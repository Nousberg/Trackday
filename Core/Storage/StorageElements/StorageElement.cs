using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Storage.StorageElements
{
    [CreateAssetMenu(fileName = "Default", menuName = "Scriptables/Storage/Elements/Default")]
    public class StorageElement : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public int MoneyPrice { get; private set; }
        [field: SerializeField] public int DiamondsPrice { get; private set; }
        [field: TextArea][field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public ElementCategory Category { get; private set; }

        [field: Space(30f)]
        [field: Header("Paint Properties")]
        [field: SerializeField] public Material DefaultMaterial { get; private set; }
        [field: SerializeField] public List<Material> SupportedMaterials { get; private set; } = new List<Material>();
        [field: SerializeField] public bool ImmutableColor { get; private set; }
        [field: SerializeField] public bool ImmutableMaterial { get; private set; }

        [field: Header("Other Properties")]
        [field: SerializeField] public Vector3 PrefabLocalPosition { get; private set; }
        [field: SerializeField] public Vector3 PrefabLocalRotation { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public float Weight { get; private set; }

        public enum ElementCategory : byte
        {
            Vehicle,
            Suspension,
            Spring,
            Engine,
            Wheel,
            LeftDoor,
            RightDoor,
            LeftDoorGlass,
            RigthDoorGlass,
            LeftDoorMirror,
            RigthDoorMirror
        }
    }
}