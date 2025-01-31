using System;

namespace Assets.Scripts.Core.Saving.SaveElements
{
    [Serializable]
    public class SavedElement
    {
        public int id;
        public SavedMaterial material;

        public SavedElement(int id, SavedMaterial material)
        {
            this.id = id;
            this.material = material;
        }
    }
}
