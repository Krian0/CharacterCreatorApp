using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacterCreator_App
{
    public partial class SpriteForm : Form
    {
        Spritesheet spritesheet = null;
        Bitmap drawArea = null;

        public SpriteForm()
        {
            InitializeComponent();
            drawArea = new Bitmap(pictureBox.Width, pictureBox.Height);
        }

        private void SpriteForm_Activated(object sender, EventArgs e)
        {
            MdiClient parent = Parent as MdiClient;

            if (parent != null)
            {
                foreach (Form child in parent.MdiChildren)
                {
                    if (child.GetType() == typeof(SpriteSheetForm))
                    {
                        SpriteSheetForm sheet = child as SpriteSheetForm;
                        Spritesheet ss = sheet.Spritesheet;

                        if (ss != null && !comboBoxSheets.Items.Contains(ss))
                        {
                            comboBoxSheets.Items.Add(ss);
                        }
                    }
                }
            }

            if (spritesheet != null)
                comboBoxSheets.SelectedItem = spritesheet;
            else if (comboBoxSheets.Items.Count > 0)
            {
                comboBoxSheets.SelectedIndex = 0;
                spritesheet = comboBoxSheets.SelectedItem as Spritesheet;
            }
        }

        SpriteSheetForm FindSheet()
        {
            MdiClient parent = Parent as MdiClient;
            if (parent != null)
            {
                foreach (Form child in parent.MdiChildren)
                {
                    if (child.GetType() == typeof(SpriteSheetForm))
                    {
                        SpriteSheetForm sheet = child as SpriteSheetForm;
                        if (sheet.Spritesheet == spritesheet)
                            return sheet;
                    }
                }
            }

            return null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (spritesheet != null)
            {
                SpriteSheetForm sheet = FindSheet();

                if (sheet != null)
                {
                    listBoxLayers.Items.Add(sheet.CurrentTile);
                    DrawCharacter();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxLayers.SelectedIndex >= 0 && listBoxLayers.SelectedIndex < listBoxLayers.Items.Count)
            {
                listBoxLayers.Items.RemoveAt(listBoxLayers.SelectedIndex);
                DrawCharacter();
            }
        }

        private void DrawCharacter()
        {
            Graphics g = Graphics.FromImage(drawArea);
            g.FillRectangle(Brushes.White, 0, 0, drawArea.Width, drawArea.Height);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            RectangleF dest = new RectangleF(0, 0, drawArea.Width, drawArea.Height);
            float tileWidth = spritesheet.GridWidth + spritesheet.Spacing;
            float tileHeight = spritesheet.GridHeight + spritesheet.Spacing;

            foreach (PointF tile in listBoxLayers.Items)
            {
                RectangleF source = new RectangleF(tile.X, tile.Y, tileWidth, tileHeight);

                g.DrawImage(spritesheet.Image, dest, source, GraphicsUnit.Pixel);
            }

            g.Dispose();

            pictureBox.Image = drawArea;
        }

        private void comboBoxSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLayers.Items.Clear();
            spritesheet = comboBoxSheets.SelectedItem as Spritesheet;

            Graphics g = Graphics.FromImage(drawArea);
            g.FillRectangle(Brushes.White, 0, 0, drawArea.Width, drawArea.Height);
            g.Dispose();
            pictureBox.Image = drawArea;
        }
    }
}
