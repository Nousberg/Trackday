using Assets.Scripts.Core.Storage.DynamicElements;
using Assets.Scripts.Core.Storage.StorageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Core.Storage
{
    [RequireComponent(typeof(DataContainer))]
    public class PlayerElementsStorage : MonoBehaviour
    {
        public event Action<StorageElement> OnElementAdded;
        public event Action<StorageElement> OnElementRemoved;

        public event Action<StorageElement> OnVehicleChildElementChanged;
        public event Action<StorageElement> OnElementMaterialChanged;

        public List<DynamicElement> GetElements => elements;

        private DataContainer container => GetComponent<DataContainer>();

        private List<DynamicElement> elements = new List<DynamicElement>();

        public void AddElement(int id)
        {
            StorageElement findedElement = container.AllIngameElements.Find(n => n.Id == id);

            if (findedElement != null)
            {
                if (findedElement is VehicleElement vehicle)
                {
                    int vehicleId = GenerateElementId();
                    DynamicVehicle vehicleInstance = new DynamicVehicle(new List<int>(), vehicle, null, vehicleId);

                    GenerateVehicleInstance(vehicleId, vehicleInstance, vehicle);

                    elements.Add(vehicleInstance);
                    OnElementAdded?.Invoke(findedElement);
                }
                else
                {
                    switch (findedElement.Category)
                    {
                        case StorageElement.ElementCategory.Suspension:
                            break;
                            break;
                        case StorageElement.ElementCategory.Spring:
                            break;
                        case StorageElement.ElementCategory.Wheel:
                            break;
                        case StorageElement.ElementCategory.LeftDoor:
                            break;
                        case StorageElement.ElementCategory.RightDoor:
                            break;
                        case StorageElement.ElementCategory.LeftDoorGlass:
                            break;
                        case StorageElement.ElementCategory.RigthDoorGlass:
                            break;
                        case StorageElement.ElementCategory.LeftDoorMirror:
                            break;
                        case StorageElement.ElementCategory.RigthDoorMirror:
                            break;
                        default:
                            elements.Add(new DynamicElement(findedElement, findedElement.DefaultMaterial, GenerateElementId()));
                            break;
                    }
                    
                    OnElementAdded?.Invoke(findedElement);
                }
            }
        }
        public void RemoveElement(int index)
        {
            if (index < 0 || index >= elements.Count)
                return;

            OnElementRemoved?.Invoke(elements[index].data);

            List<DynamicVehicle> vehicles = elements
                .Where(n => n.data.Category == StorageElement.ElementCategory.Vehicle)
                .OfType<DynamicVehicle>()
                .ToList();

            DynamicVehicle owVehicle = vehicles.Find(n => n.elements.Contains(index));

            if (owVehicle != null)
                owVehicle.elements.Remove(index);

            if (elements[index].data.Category == StorageElement.ElementCategory.Wheel)
            {
                List<DynamicElement> ownerVehicles = elements.FindAll(n => n.data.Category == StorageElement.ElementCategory.Vehicle);

                if (ownerVehicles != null)
                    foreach (var ownerVehicle in ownerVehicles)
                    {
                        if (ownerVehicle is DynamicVehicle vehicle)
                            foreach (var element in vehicle.elements)
                            {
                                if (elements[element] is DynamicSuspension dSuspension)
                                    foreach (var spring in dSuspension.springs)
                                        if (elements[spring] is DynamicSpring dSpring)
                                            if (dSpring.wheel == elements[index].myId)
                                            {
                                                dSpring.wheel = -1;
                                                break;
                                            }
                                break;
                            }
                        break;
                    }
            }

            elements.RemoveAt(index);
        }
        public void SetVehicleChildElement(int vehicleIndex, int childElementIndex)
        {
            if (vehicleIndex < 0 || vehicleIndex >= elements.Count || childElementIndex < 0 || childElementIndex >= elements.Count)
                return;

            if (elements[vehicleIndex].data is VehicleElement vehicle && elements[vehicleIndex] is DynamicVehicle dVehicle)
            {
                if (vehicle.CustomizableElements.Contains(elements[childElementIndex].data.Category))
                {
                    if (vehicle.SupportedElements.Contains(elements[childElementIndex].data))
                    {
                        DynamicElement sameTypeChild = elements.Find(n => n.data.Category == elements[childElementIndex].data.Category && n.ownerId == elements[vehicleIndex].myId);

                        if (sameTypeChild != null)
                            sameTypeChild.ownerId = -1;

                        if (dVehicle.elements.Contains(sameTypeChild.myId))
                            dVehicle.elements.Remove(sameTypeChild.myId);

                        if (elements[childElementIndex] is DynamicWheel wheel && sameTypeChild is DynamicWheel sameWheel)
                        {
                            DynamicSuspension vehicleSuspension = null;

                            foreach (var element in dVehicle.elements)
                                if (elements[element] is DynamicSuspension suspension)
                                    vehicleSuspension = suspension;

                            if (vehicleSuspension != null)
                            {
                                foreach (var spring in vehicleSuspension.springs)
                                    if (elements[spring] is DynamicSpring dSpring)
                                    {
                                        DynamicWheel dWheel = elements[dSpring.wheel] as DynamicWheel;
                                        wheel.slot = dWheel.slot;
                                        dWheel.ownerId = -1;
                                        dSpring.wheel = wheel.myId;
                                    }

                                wheel.slot = sameWheel.slot;
                            }
                        }
                    }
                }
            }
        }
        public void SetElementMaterial(int index, Material material)
        {
            if (index < 0 || index >= elements.Count)
                return;

            if (elements[index].data.SupportedMaterials.Contains(material) && !elements[index].data.ImmutableMaterial)
            {
                elements[index].currentMaterial = material;
                OnElementMaterialChanged?.Invoke(elements[index].data);
            }
        }

        private void GenerateVehicleInstance(int vehicleId, DynamicVehicle vehicleInstance, VehicleElement vehicle)
        {
            List<StorageElement> vehicleBaseElements = vehicle.BaseElements;
            List<int> vehicleElements = new List<int>();

            WheelElement wheelData = vehicle.BaseElements.Find(n => n.Category == StorageElement.ElementCategory.Wheel) as WheelElement;
            SpringElement springData = vehicle.BaseElements.Find(n => n.Category == StorageElement.ElementCategory.Spring) as SpringElement;
            SuspensionElement suspensionData = vehicle.BaseElements.Find(n => n.Category == StorageElement.ElementCategory.Suspension) as SuspensionElement;

            DynamicSuspension suspensionInstance = new DynamicSuspension(new List<int>(), suspensionData.DefaultWheelDistance, suspensionData.DefaultWheelAngle, suspensionData, suspensionData.DefaultMaterial, GenerateElementId(), vehicleId);

            for (int i = 0; i < vehicle.MaxWheels; i++)
            {
                DynamicWheel wheel = new DynamicWheel(i, wheelData, wheelData.DefaultMaterial, GenerateElementId(), vehicleId);
                DynamicSpring spring = new DynamicSpring(wheel.myId, springData.Heigth, springData.Elasticity, springData, springData.DefaultMaterial, GenerateElementId(), vehicleId);

                suspensionInstance.springs.Add(spring.myId);
                elements.Add(spring);
                elements.Add(wheel);
            }

            vehicleElements.Add(suspensionInstance.myId);
            elements.Add(suspensionInstance);

            DoorElement rigthDoor = vehicle.BaseElements.Find(n => n.Category == StorageElement.ElementCategory.RightDoor) as DoorElement;
            DoorElement leftDoor = vehicle.BaseElements.Find(n => n.Category == StorageElement.ElementCategory.LeftDoor) as DoorElement;

            for (int i = 0; i < vehicle.MaxRigthDoors; i++)
            {
                DynamicElement rigthDoorGlassInstance = new DynamicElement(rigthDoor.DefaultGlass, rigthDoor.DefaultGlass.DefaultMaterial, GenerateElementId(), vehicleId);
                DynamicElement rigthDoorMirrorInstance = new DynamicElement(rigthDoor.DefaultMirror, rigthDoor.DefaultMirror.DefaultMaterial, GenerateElementId(), vehicleId);
                DynamicDoor rigthDoorInstance = new DynamicDoor(rigthDoorGlassInstance.myId, rigthDoorMirrorInstance.myId, rigthDoor, rigthDoor.DefaultMaterial, GenerateElementId(), vehicleId);

                vehicleElements.Add(rigthDoorInstance.myId);
                elements.Add(rigthDoorInstance);
                elements.Add(rigthDoorGlassInstance);
                elements.Add(rigthDoorMirrorInstance);
            }
            for (int i = 0; i < vehicle.MaxLeftDoors; i++)
            {
                DynamicElement leftDoorGlassInstance = new DynamicElement(leftDoor.DefaultGlass, leftDoor.DefaultGlass.DefaultMaterial, GenerateElementId(), vehicleId);
                DynamicElement leftDoorMirrorInstance = new DynamicElement(leftDoor.DefaultMirror, leftDoor.DefaultMirror.DefaultMaterial, GenerateElementId(), vehicleId);
                DynamicDoor leftDoorInstance = new DynamicDoor(leftDoorGlassInstance.myId, leftDoorMirrorInstance.myId, leftDoor, leftDoor.DefaultMaterial, GenerateElementId(), vehicleId);

                vehicleElements.Add(leftDoorInstance.myId);
                elements.Add(leftDoorInstance);
                elements.Add(leftDoorGlassInstance);
                elements.Add(leftDoorMirrorInstance);
            }

            vehicleBaseElements.Remove(wheelData);
            vehicleBaseElements.Remove(springData);
            vehicleBaseElements.Remove(suspensionData);

            foreach (var element in vehicleBaseElements)
            {
                DynamicElement elementInstance = new DynamicElement(element, element.DefaultMaterial, GenerateElementId(), vehicleId);

                vehicleElements.Add(elementInstance.myId);
                elements.Add(elementInstance);
            }

            vehicleInstance.elements = vehicleElements;
        }
        private int GenerateElementId()
        {
            int result;

            if (elements.Count > 0)
                result = elements.OrderByDescending(e => e.myId).First().myId + 1;
            else
                result = 0;

            return result;
        }
    }
}