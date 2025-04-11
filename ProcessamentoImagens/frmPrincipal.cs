using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using ProcessamentoImagens.Tools;

namespace ProcessamentoImagens
{
    public partial class frmPrincipal : Form
    {
        private Image image;
        private Bitmap imageBitmap;
        private double brightness;
        private HSI[][] hsiValues;
        private CMY[][] cmyValues;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void OpenImage(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Imagem (*.jpg;*.gif;*.bmp;*.png;*.jpeg)|*.jpg;*.gif;*.bmp;*.png;*.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictBoxImg1.Image = image;
                pictBoxImg1.SizeMode = PictureBoxSizeMode.StretchImage;
                operationLabel.Text = "Carregando imagem...";
                LoadImage();
                operationLabel.Text = "Criando miniaturas...";
                LoadPictureBoxOtherChannel();
                Luminancia();
                LoadHistograma();
                operationLabel.Text = "";
            }
        }

        private void LoadImage()
        {
            brightness = 255;
            hsiValues = new HSI[image.Width][];
            cmyValues = new CMY[image.Width][];
            for (int i = 0; i < image.Width; i++)
            {
                hsiValues[i] = new HSI[image.Height];
                cmyValues[i] = new CMY[image.Height];
            }

            Bitmap bitmap = (Bitmap)image;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    RGB rgb = new RGB(pixel.R, pixel.G, pixel.B);
                    hsiValues[x][y] = Utils.ToHSI(rgb);
                    cmyValues[x][y] = Utils.ToCMY(rgb);
                    brightness = Math.Min(brightness, hsiValues[x][y].I);
                }
            }
        }

        private void Luminancia()
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap imageLuminanceBitMap = new Bitmap(width, height);
            imageBitmap = new Bitmap(image);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = imageBitmap.GetPixel(x, y);
                    int scale = (int)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
                    imageLuminanceBitMap.SetPixel(x, y, Color.FromArgb(scale, scale, scale));
                }
            }
            pictureBoxLuminancia.Image = imageLuminanceBitMap;
            pictureBoxLuminancia.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void LoadPictureBoxOtherChannel()
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap imageBitmapR = new Bitmap(width, height);
            Bitmap imageBitmapG = new Bitmap(width, height);
            Bitmap imageBitmapB = new Bitmap(width, height);
            Bitmap imageBitmapH = new Bitmap(width, height);
            Bitmap imageBitmapS = new Bitmap(width, height);
            Bitmap imageBitmapI = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    RGB rgb = Utils.ToRGB(hsiValues[x][y]);
                    imageBitmapR.SetPixel(x, y, Color.FromArgb(rgb.R, 0, 0));
                    imageBitmapG.SetPixel(x, y, Color.FromArgb(0, rgb.G, 0));
                    imageBitmapB.SetPixel(x, y, Color.FromArgb(0, 0, rgb.B));
                    int hScale = (int)(hsiValues[x][y].H / 360.0 * 255.0);
                    int sScale = (int)(hsiValues[x][y].S / 100.0 * 255.0);
                    int iScale = (int)hsiValues[x][y].I;
                    imageBitmapH.SetPixel(x, y, Color.FromArgb(hScale, hScale, hScale));
                    imageBitmapS.SetPixel(x, y, Color.FromArgb(sScale, sScale, sScale));
                    imageBitmapI.SetPixel(x, y, Color.FromArgb(iScale, iScale, iScale));
                }
            }
            pictureBoxR.Image = imageBitmapR;
            pictureBoxR.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxG.Image = imageBitmapG;
            pictureBoxG.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxB.Image = imageBitmapB;
            pictureBoxB.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH.Image = imageBitmapH;
            pictureBoxH.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS.Image = imageBitmapS;
            pictureBoxS.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxI.Image = imageBitmapI;
            pictureBoxI.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void LoadHistograma()
        {
            Histograma histograma = new Histograma(imageBitmap);
            histograma.ExibirHistograma(pictureBoxHistograma);
        }

        private void AddBrightnessButton(object sender, EventArgs e)
        {
            if (brightness < 255)
            {
                brightness += 10;
                imageBitmap = new Bitmap(image);
                ColorManipulator.AddBrightness(imageBitmap, hsiValues);
                pictBoxImg1.Image = imageBitmap;
            }
        }

        private void RemoveBrightnessButton(object sender, EventArgs e)
        {
                brightness -= 10;
                imageBitmap = new Bitmap(image);
                ColorManipulator.Removerightness(imageBitmap, hsiValues);
                pictBoxImg1.Image = imageBitmap;
            
        }

        private void DetectMouseMoviment(object sender, MouseEventArgs e)
        {
            if (image != null)
            {
                int imageWidth = pictBoxImg1.Image.Width;
                int imageHeight = pictBoxImg1.Image.Height;

                int boxWidth = pictBoxImg1.ClientSize.Width;
                int boxHeight = pictBoxImg1.ClientSize.Height;

                float scaleX = (float)imageWidth / boxWidth;
                float scaleY = (float)imageHeight / boxHeight;

                int x = (int)(e.X * scaleX);
                int y = (int)(e.Y * scaleY);
                if (x < image.Width && y < image.Height)
                {
                    RGB rgb = Utils.ToRGB(hsiValues[x][y]);
                    valuesOfChannelLabel.Text = $"R: {rgb.R}, G: {rgb.G}, B: {rgb.B}\nH: {hsiValues[x][y].H}º, S: {hsiValues[x][y].S}%, I: {hsiValues[x][y].I}\nC: {cmyValues[x][y].C}, M: {cmyValues[x][y].M}, Y: {cmyValues[x][y].Y}";
                }

            }

        }

        private void IsolarFaixaHue(object sender, EventArgs e)
        {
            int initialValue = int.Parse(textBoxFaixa1.Text);
            int finalValue = int.Parse(textBoxFaixa2.Text);

            ColorManipulator.FilterRangeHue(initialValue, finalValue, imageBitmap, hsiValues);
            pictBoxImg1.Image = imageBitmap;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void addHue_Click(object sender, EventArgs e)
        {
            imageBitmap = new Bitmap(image);
            ColorManipulator.AdjustHue(imageBitmap, hsiValues, +10);
            pictBoxImg1.Image = imageBitmap;
        }

        private void removeHue_Click(object sender, EventArgs e)
        {
            imageBitmap = new Bitmap(image);
            ColorManipulator.AdjustHue(imageBitmap, hsiValues, -10);
            pictBoxImg1.Image = imageBitmap;
        }
    }
}
