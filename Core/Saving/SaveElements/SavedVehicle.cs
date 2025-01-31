using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core.Saving.SaveElements
{
    [Serializable]
    public class SavedVehicle
    {
        public int id;
        public List<SavedElement> elements = new List<SavedElement>();

        public SavedVehicle(int id, List<SavedElement> elements)
        {
            this.id = id;
            this.elements = elements;
        }
    }
}
