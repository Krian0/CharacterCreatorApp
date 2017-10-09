using System;
using System.Drawing;

namespace CharacterCreator_App
{
    class Layer
    {
        public string Name { get; set; }
        public Point TileCoordinates { get; set; }
        public int Priority { get; set; }

        public Layer(string name)
        {
            this.Name = name;
        }

        public Layer(string name, Point coordinates)
        {
            this.Name = name;
            this.TileCoordinates = coordinates;
        }
    }
}
