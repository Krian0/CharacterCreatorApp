using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacterCreator_App
{
    public partial class SpriteSheetForm : Form
    {
        public Spritesheet Spritesheet { get; private set; }
        Bitmap drawArea;

        public PointF CurrentTile { get; private set; }

        public string Filename { get { return (Spritesheet != null) ? Spritesheet.Filename : string.Empty; } }


        public SpriteSheetForm()
        {
            InitializeComponent();

            drawArea = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    Spritesheet = new Spritesheet(dlg.FileName);
                    drawGrid();
                    this.Text = dlg.SafeFileName;
                }
            }
        }

        private void drawGrid()
        {
            pictureBox1.DrawToBitmap(drawArea, pictureBox1.Bounds);

            Graphics g;
            g = Graphics.FromImage(drawArea);

            g.Clear(Color.White);

            if (Spritesheet != null)
                g.DrawImage(Spritesheet.Image, 0, 0);


            Pen pen = new Pen(Brushes.Black);

            float width = pictureBox1.Width;
            float height = pictureBox1.Height;
        
            for (float x = 0; x < width; x += Spritesheet.GridWidth + Spritesheet.Spacing)
                g.DrawLine(pen, x, 0, x, height);

            for (float y = 0; y < height; y += Spritesheet.GridHeight + Spritesheet.Spacing)
                g.DrawLine(pen, 0, y, width, y);


            Pen highlight = new Pen(Brushes.Red);
            g.DrawRectangle(highlight, CurrentTile.X, CurrentTile.Y, Spritesheet.GridWidth + Spritesheet.Spacing, Spritesheet.GridHeight + Spritesheet.Spacing);


            g.Dispose();

            pictureBox1.Image = drawArea;
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            Spritesheet.GridWidth = (float)numericUpDownWidth.Value;
            drawGrid();

            numericUpDownWidth.Text = Spritesheet.GridWidth.ToString();
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            Spritesheet.GridHeight = (float)numericUpDownHeight.Value;
            drawGrid();

            numericUpDownHeight.Text = Spritesheet.GridHeight.ToString();
        }

        private void numericUpDownSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            Spritesheet.Spacing = (float)numericUpDownSpacing.Value;
            drawGrid();

            numericUpDownSpacing.Text = Spritesheet.Spacing.ToString();
        }

        private void SpriteSheetForm_Shown(object sender, EventArgs e)
        {
            drawGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Spritesheet == null)
                return;

            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mouse = e as MouseEventArgs;

                float tileWidth = Spritesheet.GridWidth + Spritesheet.Spacing;
                float tileHeight = Spritesheet.GridHeight + Spritesheet.Spacing;

                for (float x = 0; x < pictureBox1.Width; x += tileWidth)
                    for (float y = 0; y < pictureBox1.Height; y += tileHeight)
                        if (mouse.X >= x && mouse.X <= x + tileWidth && mouse.Y >= y && mouse.Y <= y + tileHeight)
                            CurrentTile = new PointF(x, y);

                drawGrid();
            }
        }


    }
}
