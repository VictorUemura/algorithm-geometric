using System;
using System.Drawing;
using ProcessamentoImagens.Tools;

namespace ProcessamentoImagens.Graficos
{
    class Elipse
    {

        private readonly Graphics g;
        private readonly Bitmap bmp;
        private readonly Color corDesenho;

        public Elipse(Graphics graphics, Bitmap bitmap, Color cor)
        {
            this.g = graphics ?? throw new ArgumentNullException(nameof(graphics));
            this.bmp = bitmap ?? throw new ArgumentNullException(nameof(bitmap));
            this.corDesenho = cor;
        }

        // --- Algoritmo Ponto Médio ---
        public void DesenharElipsePontoMedio(Point center, int rx, int ry)
        {
            if (rx <= 0 || ry <= 0) return;

            long rxSq = (long)rx * rx; // Usar long para evitar overflow nos quadrados
            long rySq = (long)ry * ry;
            long twoRxSq = 2 * rxSq;
            long twoRySq = 2 * rySq;
            long p;
            int x = 0;
            int y = ry;
            int cx = center.X;
            int cy = center.Y;

            // Desenha pontos iniciais (0, ry), (0, -ry) e simétricos (implícito na DrawEllipsePoints)
            Desenho.DrawEllipsePoints(g, bmp, cx, cy, x, y, corDesenho);

            // Região 1 (dy/dx > -1)
            p = (long)Math.Round(rySq - rxSq * ry + 0.25 * rxSq);
            while (twoRySq * x < twoRxSq * y) // Enquanto a inclinação é < 1 em magnitude
            {
                x++;
                if (p < 0)
                {
                    p += twoRySq * x + rySq;
                }
                else
                {
                    y--;
                    p += twoRySq * x - twoRxSq * y + rySq;
                }
                Desenho.DrawEllipsePoints(g, bmp, cx, cy, x, y, corDesenho);
            }

            // Região 2 (dy/dx <= -1)
            // Ponto inicial da região 2 é o último ponto da região 1
            p = (long)Math.Round(rySq * (x + 0.5) * (x + 0.5) + rxSq * (y - 1) * (y - 1) - rxSq * rySq);
            while (y > 0)
            {
                y--;
                if (p > 0)
                {
                    p += -twoRxSq * y + rxSq;
                }
                else
                {
                    x++;
                    p += twoRySq * x - twoRxSq * y + rxSq;
                }
                Desenho.DrawEllipsePoints(g, bmp, cx, cy, x, y, corDesenho);
            }
        }
    }
}
