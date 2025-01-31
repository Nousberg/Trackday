using UnityEngine;

namespace Assets.Scripts.CoreUi
{
    public class MenuData : MonoBehaviour
    {
        [field: SerializeField] public MenuSwitcher.Menu MenuType { get; private set; }
    }
}
