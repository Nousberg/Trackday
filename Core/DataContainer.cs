using Assets.Scripts.Core.Storage.StorageElements;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class DataContainer : MonoBehaviour
    {
        [field: SerializeField] public List<StorageElement> AllIngameElements { get; private set; } = new List<StorageElement>();
    }
}
