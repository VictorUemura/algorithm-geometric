using System;
using System.Drawing;
using ProcessamentoImagens.Tools;

namespace ProcessamentoImagens.Graficos
{
    class Reta
    {

        private readonly Graphics g;
        private readonly Bitmap bmp;
        private readonly Color corDesenho;

        public Reta(Graphics graphics, Bitmap bitmap, Color cor)
        {
            this.g = graphics ?? throw new ArgumentNullException(nameof(graphics));
            this.bmp = bitmap ?? throw new ArgumentNullException(nameof(bitmap));
            this.corDesenho = cor;
        }

        // --- Algoritmo DDA ---
        public void DesenharRetaDDA(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;

            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (steps == 0)
            {
                Desenho.DrawPixel(g, bmp, p1.X, p1.Y, corDesenho);
                return;
            }

            float xIncrement = dx / (float)steps;
            float yIncrement = dy / (float)steps;

            float x = p1.X + 0.5f; // Adiciona 0.5 para melhor arredondamento
            float y = p1.Y + 0.5f;

            for (int i = 0; i <= steps; i++)
            {
                Desenho.DrawPixel(g, bmp, (int)x, (int)y, corDesenho);
                x += xIncrement;
                y += yIncrement;
            }
        }

        // --- Algoritmo Ponto Médio (Bresenham) ---
        // Implementação simplificada (lida com octantes por troca e sinais)
        public void DesenharRetaPontoMedio(Point p1, Point p2)
        {
            int x1 = p1.X, y1 = p1.Y;
            int x2 = p2.X, y2 = p2.Y;
            bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            // Troca x/y se a inclinação for > 1
            if (steep)
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
            }

            // Garante que estamos desenhando da esquerda para a direita
            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }

            int dx = x2 - x1;
            int dy = Math.Abs(y2 - y1); // Usa valor absoluto
            int error = dx / 2;
            int ystep = (y1 < y2) ? 1 : -1; // Define se y incrementa ou decrementa
            int y = y1;

            for (int x = x1; x <= x2; x++)
            {
                // Desenha o pixel (trocado de volta se necessário)
                if (steep)
                    Desenho.DrawPixel(g, bmp, y, x, corDesenho);
                else
                    Desenho.DrawPixel(g, bmp, x, y, corDesenho);

                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        // --- Algoritmo Equação Explícita (Real) ---
        public void DesenharRetaReal(Point p1, Point p2)
        {
            int x1 = p1.X, y1 = p1.Y;
            int x2 = p2.X, y2 = p2.Y;
            int dx = x2 - x1;
            int dy = y2 - y1;

            // Caso: Reta Vertical
            if (dx == 0)
            {
                int startY = Math.Min(y1, y2);
                int endY = Math.Max(y1, y2);
                for (int y = startY; y <= endY; y++)
                {
                    Desenho.DrawPixel(g, bmp, x1, y, corDesenho);
                }
                return;
            }

            float m = (float)dy / dx; // Coeficiente angular
            float b = y1 - m * x1;    // Coeficiente linear

            // Caso: Inclinação |m| <= 1 (varia x)
            if (Math.Abs(m) <= 1)
            {
                int startX = Math.Min(x1, x2);
                int endX = Math.Max(x1, x2);
                for (int x = startX; x <= endX; x++)
                {
                    int y = (int)Math.Round(m * x + b);
                    Desenho.DrawPixel(g, bmp, x, y, corDesenho);
                }
            }
            // Caso: Inclinação |m| > 1 (varia y)
            else
            {
                int startY = Math.Min(y1, y2);
                int endY = Math.Max(y1, y2);
                for (int y = startY; y <= endY; y++)
                {
                    // Isola x: x = (y - b) / m
                    int x = (int)Math.Round((y - b) / m);
                    Desenho.DrawPixel(g, bmp, x, y, corDesenho);
                }
            }
        }

        // Função auxiliar para trocar valores
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
