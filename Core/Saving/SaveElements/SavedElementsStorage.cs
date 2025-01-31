using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core.Saving.SaveElements
{
    [Serializable]
    public class SavedElementsStorage
    {
        public List<SavedElement> elements = new List<SavedElement>();
    }
}