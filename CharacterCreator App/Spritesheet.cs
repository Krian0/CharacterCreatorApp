using System.Drawing;

namespace CharacterCreator_App
{
    class Spritesheet
    {
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        private Image image = null;
        private string filePath;

        public override string ToString()
        {
            return base.ToString() + ": " + filePath.ToString();
        }

        public int Width
        {
            get { return (image != null) ? image.Width : 0; }
        }

        public int Height
        {
            get { return (image != null) ? image.Height : 0; }
        }

        public Spritesheet(string filePath)
        {
            this.filePath = filePath;
            Load();
        }

        public void Load()
        {
            image = Image.FromFile(filePath);
        }


        //
        //Spritesheet spritesheet = null;
        //Bitmap drawArea;

        //int gridWidth = 16;
        //int gridHeight = 16;
        //int spacing = 0;

        //public SpriteSheetForm()
        //{
        //    InitializeComponent();

        //    drawArea = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //}

        //private void buttonLoad_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog dlg = new OpenFileDialog();

        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        if (dlg.CheckFileExists == true)
        //        {
        //            spritesheet = new Spritesheet(dlg.FileName);
        //            drawGrid();
        //        }
        //    }
        //}

        //private void drawGrid()
        //{
        //    pictureBox1.DrawToBitmap(drawArea, pictureBox1.Bounds);

        //    Graphics g;
        //    g = Graphics.FromImage(drawArea);

        //    g.Clear(Color.White);

        //    if (spritesheet != null)
        //    {
        //        g.DrawImage(spritesheet.Image, 0, 0);
        //    }

        //    Pen pen = new Pen(Brushes.Black);

        //    int width = pictureBox1.Width;
        //    int height = pictureBox1.Height;

        //    for (int x = 0; x < width; x += gridWidth + spacing)
        //    {
        //        g.DrawLine(pen, 0, x, height, x);
        //    }
        //    for (int y = 0; y < height; y += gridHeight + spacing)
        //    {
        //        g.DrawLine(pen, 0, y, width, y);
        //    }

        //    g.Dispose();

        //    pictureBox1.Image = drawArea;
        //}

        //private void textBoxWidth_TextChanged()
        //{
        //    if (int.TryParse(textBoxWidth.Text, out gridWidth) == true)
        //        drawGrid();

        //    textBoxWidth.Text = gridWidth.ToString();
        //}

        //private void textBoxHeight_TextChanged()
        //{
        //    if (int.TryParse(textBoxHeight.Text, out gridHeight) == true)
        //        drawGrid();

        //    textBoxHeight.Text = gridHeight.ToString();
        //}

        //private void textBoxSpacing_TextChanged(object sender, EventArgs e)
        //{
        //    if (int.TryParse(textBoxSpacing.Text, out spacing) == true)
        //        drawGrid();

        //    textBoxSpacing.Text = spacing.ToString();
        //}

        //private void SpriteSheetForm_Shown(object sender, EventArgs e)
        //{
        //    drawGrid();
        //}
    }
}
