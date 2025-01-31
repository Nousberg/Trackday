namespace Assets.Scripts.Core.Saving
{
    public class SavedColor
    {
        public readonly float r, g, b, a;

        public SavedColor(float r = float.NaN, float g = float.NaN, float b = float.NaN, float a = float.NaN)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public bool IsAssigned() => !(float.IsNaN(r) && float.IsNaN(g) && float.IsNaN(b) && float.IsNaN(a));
    }
}
