using System.Drawing;

namespace ProcessamentoImagens.Tools
{
    class Desenho
    {
        /// <summary>
        /// Desenha um único pixel no bitmap com verificação de limites.
        /// </summary>
        public static void DrawPixel(Graphics g, Bitmap bmp, int x, int y, Color color)
        {
            if (g != null && bmp != null && x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
            {
                // FillRectangle é geralmente visível e performático o suficiente para estes algoritmos.
                // Para performance extrema, LockBits seria necessário, mas adiciona complexidade.
                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, x, y, 1, 1);
                }
            }
        }

        /// <summary>
        /// Desenha pontos simétricos para um círculo (8 vias).
        /// </summary>
        public static void DrawCirclePoints(Graphics g, Bitmap bmp, int cx, int cy, int x, int y, Color color)
        {
            DrawPixel(g, bmp, cx + x, cy + y, color);
            DrawPixel(g, bmp, cx - x, cy + y, color);
            DrawPixel(g, bmp, cx + x, cy - y, color);
            DrawPixel(g, bmp, cx - x, cy - y, color);
            DrawPixel(g, bmp, cx + y, cy + x, color);
            DrawPixel(g, bmp, cx - y, cy + x, color);
            DrawPixel(g, bmp, cx + y, cy - x, color);
            DrawPixel(g, bmp, cx - y, cy - x, color);
        }

        /// <summary>
        /// Desenha pontos simétricos para uma elipse (4 vias).
        /// </summary>
        public static void DrawEllipsePoints(Graphics g, Bitmap bmp, int cx, int cy, int x, int y, Color color)
        {
            DrawPixel(g, bmp, cx + x, cy + y, color);
            DrawPixel(g, bmp, cx - x, cy + y, color);
            DrawPixel(g, bmp, cx + x, cy - y, color);
            DrawPixel(g, bmp, cx - x, cy - y, color);
        }
    }
}
