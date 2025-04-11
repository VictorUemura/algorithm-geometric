using ProcessamentoImagens.ColorType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens
{
    class Utils
    {

        public static RGB ToRGB(HSI hsi)
        {
            double h = hsi.H * Math.PI / 180.0;

            double s = hsi.S / 100.0;

            double i = hsi.I / 255.0;

            double x, y, z;

            if (h < 2 * Math.PI / 3.0) // Setor 0: 0° a 120°
            {
                x = i * (1 - s);
                y = i * (1 + (s * Math.Cos(h)) / Math.Cos((Math.PI / 3.0) - h));
                z = 3 * i - (x + y);
                return new RGB((int)(y * 255), (int)(z * 255), (int)(x * 255));
            }
            else if (h <= 4 * Math.PI / 3.0) // Setor 1: 120° a 240°
            {
                h = h - 2 * Math.PI / 3.0;
                x = i * (1 - s);
                y = i * (1 + (s * Math.Cos(h)) / Math.Cos((Math.PI / 3.0) - h));
                z = 3 * i - (x + y);
                return new RGB((int)(x * 255), (int)(y * 255), (int)(z * 255));
            }
            else // Setor 2: 240° a 360°
            {
                h = h - 4 * Math.PI / 3.0;
                x = i * (1 - s);
                y = i * (1 + (s * Math.Cos(h)) / Math.Cos((Math.PI / 3.0) - h));
                z = 3 * i - (x + y);
                return new RGB((int)(z * 255), (int)(x * 255), (int)(y * 255));
            }
        }

        public static HSI ToHSI(RGB rgb)
        {
            NormalizedRGB normalizedRGB = new NormalizedRGB(rgb);

            double h;
            if (normalizedRGB.B <= normalizedRGB.G)
            {
                h = Math.Acos((0.5 * ((normalizedRGB.R - normalizedRGB.G) + (normalizedRGB.R - normalizedRGB.B))) / Math.Sqrt(Math.Pow(normalizedRGB.R - normalizedRGB.G, 2) + (normalizedRGB.R - normalizedRGB.B) * (normalizedRGB.G - normalizedRGB.B)));
            }
            else
            {
                h = 2 * Math.PI - Math.Acos((0.5 * ((normalizedRGB.R - normalizedRGB.G) + (normalizedRGB.R - normalizedRGB.B))) / Math.Sqrt(Math.Pow(normalizedRGB.R - normalizedRGB.G, 2) + (normalizedRGB.R - normalizedRGB.B) * (normalizedRGB.G - normalizedRGB.B)));
            }

            double s = 1 - 3 * Math.Min(normalizedRGB.R, Math.Min(normalizedRGB.G, normalizedRGB.B));

            double i = (rgb.R + rgb.G + rgb.B) / (3.0 * 255);
            if (h is double.NaN)
            {
                h = 0;
            }
            else
            {
                h = h * 180 / Math.PI;
            }
            s = s * 100;
            i = i * 255;

            return new HSI(h, s, i);
        }

        public static CMY ToCMY(RGB rgb)
        {
            return new CMY(255 - rgb.R, 255 - rgb.G, 255 - rgb.B);
        }

    }
}
