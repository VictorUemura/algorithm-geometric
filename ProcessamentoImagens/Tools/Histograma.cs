using System.Drawing;
using System.Windows.Forms;

namespace ProcessamentoImagens.Tools
{
    internal class Histograma
    {
        private int[] histogramaValores;

        public Histograma(Bitmap imagem)
        {
                CalcularHistograma(imagem);
        }

        private void CalcularHistograma(Bitmap imagem)
        {
            histogramaValores = new int[256];

            for (int y = 0; y < imagem.Height; y++)
            {
                for (int x = 0; x < imagem.Width; x++)
                {
                    Color cor = imagem.GetPixel(x, y);
                    int value = (int)(0.299 * cor.R + 0.587 * cor.G + 0.114 * cor.B);
                    histogramaValores[value]++;
                }
            }
        }

        public void ExibirHistograma(PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);

                int max = 0;
                for (int i = 0; i < 256; i++)
                {
                    if (histogramaValores[i] > max) max = histogramaValores[i];
                }

                for (int i = 0; i < 256; i++)
                {
                    int altura = (int)((double)histogramaValores[i] / max * pictureBox.Height);
                    g.DrawLine(Pens.Black, i, pictureBox.Height - 1, i, pictureBox.Height - altura - 1);
                }
            }
            pictureBox.Image = bitmap;
        }

    }
}
