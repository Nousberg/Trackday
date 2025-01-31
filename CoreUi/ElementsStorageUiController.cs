using Assets.Scripts.Core.Storage;
using Assets.Scripts.Core.Storage.DynamicElements;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CoreUi
{
    [RequireComponent(typeof(PlayerElementsStorage))]
    [RequireComponent(typeof(MenuSwitcher))]
    public class ElementsStorageUiController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button vehicleEquip;
        [SerializeField] private Button elementEquip;

        [Header("Parents")]
        [SerializeField] private GameObject vehicleElementsParent;
        [SerializeField] private GameObject vehicleKitsParent;

        [Header("Other")]
        [SerializeField] private Transform vehicleElementsContainer;

        private PlayerElementsStorage storage => GetComponent<PlayerElementsStorage>();
        private MenuSwitcher menuSwitcher => GetComponent<MenuSwitcher>();
        private TextMeshProUGUI equippedCarButtonText => vehicleEquip.GetComponent<TextMeshProUGUI>();

        private List<DynamicVehicle> vehicles = new List<DynamicVehicle>();
        private List<GameObject> buildedVehicleElements = new List<GameObject>();
        private List<GameObject> vehicleElements = new List<GameObject>();
        private int equippedVehicleIndex = -1;
        private int userSelectedVehicle = -1;

        public void Init()
        {
            menuSwitcher.OnMenuSwitch += HandleCurrentMenu;
        }

        private void HandleCurrentMenu(MenuSwitcher.Menu type)
        {
            if (type == MenuSwitcher.Menu.Garage)
            {
                foreach (var element in storage.GetElements)
                    if (element is DynamicVehicle vehicle)
                        vehicles.Add(vehicle);

                SelectVehicle(0);
            }
        }
        private void EquipVehicle(int index)
        {
            if (index < 0 || index >= vehicles.Count)
                return;

            equippedVehicleIndex = index;

            SetEquipped(index);
        }
        private void SelectVehicle(int index)
        {
            if (index < 0 || index >= vehicles.Count)
                return;

            userSelectedVehicle = index;

            vehicleEquip.onClick.RemoveAllListeners();
            vehicleEquip.onClick.AddListener(() => EquipVehicle(userSelectedVehicle));

            if (equippedVehicleIndex == userSelectedVehicle)
                SetEquipped(userSelectedVehicle);
            else
                SetUnequipped();

            BuildVehicleModel(userSelectedVehicle);
        }
        private void ApplyKitToSelectedVehicle(int index)
        {

        }
        private void ShowAviableElementsForSelectedVehicle()
        {
            vehicleElements.ForEach(n => Destroy(n));
            vehicleElements.Clear();

            foreach (var element in vehicles[userSelectedVehicle].elements)
            {
                GameObject elementInstance = new GameObject();
                Button b = elementInstance.AddComponent<Button>();
                Image i = elementInstance.AddComponent<Image>();

                b.onClick.AddListener(() => storage.SetVehicleChildElement(storage.GetElements.IndexOf(vehicles[userSelectedVehicle]), element));
                i.sprite = storage.GetElements[element].data.Icon;
            }
        }
        private void BuildVehicleModel(int index)
        {
            buildedVehicleElements.ForEach(n => Destroy(n));
            buildedVehicleElements.Clear();

            foreach (var element in vehicles[userSelectedVehicle].elements)
            {
                GameObject elementInstance = Instantiate(storage.GetElements[element].data.Prefab, storage.GetElements[element].data.PrefabLocalPosition, Quaternion.Euler(storage.GetElements[element].data.PrefabLocalRotation));
                elementInstance.transform.parent = vehicleElementsContainer;
                buildedVehicleElements.Add(elementInstance);
            }
        }
        private void SelectEquippedVehicle() => SelectVehicle(equippedVehicleIndex);
        private void SetSelectedVehicleViaOffset(int indexOffset) => SelectVehicle(userSelectedVehicle + indexOffset);
        private void SetEquipped(int index) => equippedCarButtonText.text = "Equipped";
        private void SetUnequipped() => equippedCarButtonText.text = "Unequipped";
    }
}
