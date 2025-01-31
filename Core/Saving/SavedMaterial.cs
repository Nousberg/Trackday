namespace Assets.Scripts.Core.Saving
{
    public class SavedMaterial
    {
        public string name;
        public SavedColor color;

        public SavedMaterial(string name, SavedColor color)
        {
            this.name = name;
            this.color = color;
        }
    }
}
