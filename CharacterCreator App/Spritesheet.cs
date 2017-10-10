using System.Drawing;

namespace CharacterCreator_App
{
    public class Spritesheet
    {
        public string Path { get; private set; }

        public float GridWidth { get; set; } = 16;
        public float GridHeight { get; set; } = 16;
        public float Spacing { get; set; } = 0;
        public string Filename { get { return Path.Substring(Path.LastIndexOf("\\")); } }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        private Image image = null;

        public override string ToString()
        {
            return Filename;
        }

        public int Width
        {
            get { return (image != null) ? image.Width : 0; }
        }

        public int Height
        {
            get { return (image != null) ? image.Height : 0; }
        }

        public Spritesheet(string path)
        {
            Path = path;
            Load();
        }

        public void Load()
        {
            image = Image.FromFile(Path);
        }
    }
}
