using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.ColorType
{
    class NormalizedRGB
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
        public NormalizedRGB(RGB rgb)
        {
            double sumRGB = rgb.R + rgb.G + rgb.B;
            if (sumRGB == 0)
            {
                R = 0;
                G = 0;
                B = 0;
            }
            else
            {
                R = (double)rgb.R / sumRGB;
                G = (double)rgb.G / sumRGB;
                B = (double)rgb.B / sumRGB;
            }
        }
    }
}
