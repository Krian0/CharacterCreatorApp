using System.Drawing;
using System.Collections.Generic;

namespace CharacterCreator_App
{
    class Character
    {
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name;
        public Spritesheet Spritesheet
        {
            get { return spritesheet; }
        }
        private Spritesheet spritesheet;

        private List<Layer> layers = new List<Layer>();
        //public Point tileCoordinates = new Point(0, 0);


        public Character(string name, Spritesheet spritesheet)
        {
            this.name = name;
            this.spritesheet = spritesheet;
        }

        public void AddLayer(Layer layer)
        {
            layers.Add(layer);
        }

        public override string ToString()
        {
            return "\n\n\tname: \t" + name + "\n\n\tpath: \t" + spritesheet.ToString() + "\n\n\ttile coordinates: \t" + layers[0].TileCoordinates.ToString();
        }
    }
}
