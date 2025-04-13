using System.Drawing;
using System;
using ProcessamentoImagens.Tools;

namespace ProcessamentoImagens.Graficos
{
    class Circulo
    {
        private readonly Graphics g;
        private readonly Bitmap bmp;
        private readonly Color corDesenho;

        public Circulo(Graphics graphics, Bitmap bitmap, Color cor)
        {
            this.g = graphics ?? throw new ArgumentNullException(nameof(graphics));
            this.bmp = bitmap ?? throw new ArgumentNullException(nameof(bitmap));
            this.corDesenho = cor;
        }

        // --- Algoritmo Ponto Médio (Bresenham) ---
        public void DesenharCirculoPontoMedio(Point center, int radius)
        {
            if (radius < 0) return;
            if (radius == 0) { Desenho.DrawPixel(g, bmp, center.X, center.Y, corDesenho); return; }

            int x = 0;
            int y = radius;
            int p = 1 - radius; // 5/4 - r, mas como trabalhamos com inteiros, p = 1 - r é equivalente

            // Desenha os primeiros pontos
            Desenho.DrawCirclePoints(g, bmp, center.X, center.Y, x, y, corDesenho);

            while (x < y)
            {
                x++;
                if (p < 0) // Ponto está dentro do círculo, move para Leste (E)
                {
                    p += 2 * x + 1;
                }
                else // Ponto está fora ou sobre o círculo, move para Sudeste (SE)
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }
                Desenho.DrawCirclePoints(g, bmp, center.X, center.Y, x, y, corDesenho);
            }
        }

        // --- Algoritmo Trigonométrico ---
        public void DesenharCirculoTrigonometria(Point center, int radius)
        {
            if (radius < 0) return;
            if (radius == 0) { Desenho.DrawPixel(g, bmp, center.X, center.Y, corDesenho); return; }

            // Calcula um passo angular razoável. 1/raio garante aprox. 1 pixel de distância no arco.
            double step = 1.0 / radius;

            // Itera apenas o primeiro octante (0 a PI/4) e usa simetria
            for (double angle = 0; angle <= Math.PI / 4; angle += step)
            {
                int x = (int)Math.Round(radius * Math.Cos(angle));
                int y = (int)Math.Round(radius * Math.Sin(angle));
                Desenho.DrawCirclePoints(g, bmp, center.X, center.Y, x, y, corDesenho);
            }
        }

        // --- Algoritmo Equação Explícita ---
        public void DesenharCirculoReal(Point center, int radius)
        {
            if (radius < 0) return;
            if (radius == 0) { Desenho.DrawPixel(g, bmp, center.X, center.Y, corDesenho); return; }

            int r_squared = radius * radius;

            // Itera x no primeiro octante (0 a r/sqrt(2))
            int limit = (int)Math.Round(radius / Math.Sqrt(2));
            for (int x = 0; x <= limit; x++)
            {
                // Calcula y: y = sqrt(r^2 - x^2)
                int y = (int)Math.Round(Math.Sqrt(r_squared - x * x));
                Desenho.DrawCirclePoints(g, bmp, center.X, center.Y, x, y, corDesenho);
            }
        }
    }
}
