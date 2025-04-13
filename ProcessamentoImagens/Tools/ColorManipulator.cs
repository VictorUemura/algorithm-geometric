using System.Drawing;
using System.Drawing.Imaging;

namespace ProcessamentoImagens
{
    class ColorManipulator
    {
        //sem acesso direito a memoria
        public static void negativo(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int r, g, b;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    r = cor.R;
                    g = cor.G;
                    b = cor.B;

                    //nova cor
                    Color newcolor = Color.FromArgb(255 - r, 255 - g, 255 - b);

                    imageBitmapDest.SetPixel(x, y, newcolor);
                }
            }
        }

        //com acesso direito a memoria
        public static void negativoDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            //lock dados bitmap origem 
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src1 = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src1++); //está armazenado dessa forma: b g r 
                        g = *(src1++);
                        r = *(src1++);

                        *(dst++) = (byte)(255 - b);
                        *(dst++) = (byte)(255 - g);
                        *(dst++) = (byte)(255 - r);
                    }
                    src1 += padding;
                    dst += padding;
                }
            }
            //unlock imagem origem 
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }

        public static void AddBrightness(Bitmap src, HSI[][] hsiValues)
        {
            int width = src.Width;
            int height = src.Height;
            int pixelSize = 3;

            BitmapData bitmapDataSrc = src.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);
            unsafe
            {
                byte* srcPointer = (byte*)bitmapDataSrc.Scan0.ToPointer();
               
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        hsiValues[x][y].I += 10;
                        RGB rgb;
                        if (hsiValues[x][y].I > 255)
                        {
                            HSI hsi = new HSI(hsiValues[x][y].H, hsiValues[x][y].S, 255);
                            rgb = Utils.ToRGB(hsi);
                        }
                        else
                        {
                            rgb = Utils.ToRGB(hsiValues[x][y]);
                        }

                        *(srcPointer++) = (byte)rgb.B;
                        *(srcPointer++) = (byte)rgb.G;
                        *(srcPointer++) = (byte)rgb.R;
                    }
                    srcPointer += padding;
                }
            }
            src.UnlockBits(bitmapDataSrc);
        }

        public static void Removerightness(Bitmap src, HSI[][] hsiValues)
        {
            int width = src.Width;
            int height = src.Height;
            int pixelSize = 3;

            BitmapData bitmapDataSrc = src.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);
            unsafe
            {
                byte* srcPointer = (byte*)bitmapDataSrc.Scan0.ToPointer();
              
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        hsiValues[x][y].I -= 10;
                        RGB rgb;
                        if (hsiValues[x][y].I > 255)
                        {
                            HSI hsi = new HSI(hsiValues[x][y].H, hsiValues[x][y].S, 255);
                            rgb = Utils.ToRGB(hsi);
                        }
                        else
                        {
                            rgb = Utils.ToRGB(hsiValues[x][y]);
                        }

                        *(srcPointer++) = (byte)rgb.B;
                        *(srcPointer++) = (byte)rgb.G;
                        *(srcPointer++) = (byte)rgb.R;
                    }
                    srcPointer += padding;
                }
            }
            src.UnlockBits(bitmapDataSrc);
        }

        public static void AdjustHue(Bitmap src, HSI[][] hsiValues, int hueAdjustment)
        {
            int width = src.Width;
            int height = src.Height;
            int pixelSize = 3;

            BitmapData bitmapDataSrc = src.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);
            unsafe
            {
                byte* srcPointer = (byte*)bitmapDataSrc.Scan0.ToPointer();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        hsiValues[x][y].H = (hsiValues[x][y].H + hueAdjustment) % 360;
                        if (hsiValues[x][y].H < 0) hsiValues[x][y].H = 0;

                        RGB rgb = Utils.ToRGB(hsiValues[x][y]);

                        *(srcPointer++) = (byte)rgb.B;
                        *(srcPointer++) = (byte)rgb.G;
                        *(srcPointer++) = (byte)rgb.R;
                    }
                    srcPointer += padding;
                }
            }
            src.UnlockBits(bitmapDataSrc);
        }

        public static void FilterRangeHue(int valueOne, int valueTwo, Bitmap src, HSI[][] hsiValues)
        {
            int width = src.Width;
            int height = src.Height;
            int pixelSize = 3;
            BitmapData bitmapDataSrc = src.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int padding = bitmapDataSrc.Stride - (width * pixelSize);
            unsafe
            {
                byte* srcPointer = (byte*)bitmapDataSrc.Scan0.ToPointer();
               
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (valueOne <= valueTwo)
                            if (hsiValues[x][y].H >= valueOne && hsiValues[x][y].H <= valueTwo)
                            {
                                //*(srcPointer++) = 255;
                                //*(srcPointer++) = 255;
                                //*(srcPointer++) = 255;
                                srcPointer += 3;
                            }
                            else
                            {
                                *(srcPointer++) = 0;
                                *(srcPointer++) = 0;
                                *(srcPointer++) = 0;
                            }
                        else
                        {
                            if (hsiValues[x][y].H >= valueOne || hsiValues[x][y].H <= valueTwo)
                            {
                                //*(srcPointer++) = 255;
                                //*(srcPointer++) = 255;
                                //*(srcPointer++) = 255;
                                srcPointer += 3;
                            }
                            else
                            {
                                *(srcPointer++) = 0;
                                *(srcPointer++) = 0;
                                *(srcPointer++) = 0;
                            }
                        }
                    }
                    srcPointer += padding;
                }
            }
            src.UnlockBits(bitmapDataSrc);
        }
    }
}
