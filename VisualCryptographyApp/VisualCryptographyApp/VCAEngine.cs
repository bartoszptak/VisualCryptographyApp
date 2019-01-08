using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace VisualCryptographyApp
{
    class VCAEngine
    {
        private string[] czarne2 = { "1001", "0110" };
        private string[] biale2 = { "1010", "0101" };
        private string[] czarne4 = { "00111100", "11000011", "01011010", "10100101", "10010110", "01101001" };
        private string[] biale4 = { "00110011", "11001100", "01010101", "10101010", "10011001", "01100110" };


        private bool IsPixelBlack(Color color)
        {
            if ((int)color.R < 128 && (int)color.G < 128 && (int)color.B < 128) return true;
            else return false;
        }


        private Color CharToColor(char c)
        {
            if (c == '0')
                return Color.White;
            else return Color.Black;
        }

        public bool IsSameColor(Color first, Color second)
        {
            if (first.A.Equals(second.A)
                && first.R.Equals(second.R)
                && first.G.Equals(second.G)
                && first.B.Equals(second.B))
                return true;
            else
                return false;
        }

        public Bitmap[] Create_2(string path)
        {
            Bitmap[] result = new Bitmap[2];
            Bitmap img = new Bitmap(path);

            Random rng = new Random();
            Bitmap imgSekret1 = new Bitmap(img.Width * 2, img.Height);
            Bitmap imgSekret2 = new Bitmap(img.Width * 2, img.Height);

            Color temp;
            int pom;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    pom = rng.Next(0, 2);
                    temp = img.GetPixel(i, j);
                    if ((int)temp.R < 128 && (int)temp.G < 128 && (int)temp.B < 128)
                    {
                        temp = Color.Black;
                    }
                    else
                    {
                        temp = Color.White;
                    }

                        if (IsSameColor(temp, Color.White))
                    {
                        if (pom == 0)
                        {
                            imgSekret1.SetPixel(i * 2, j, CharToColor(biale2[0][0]));
                            imgSekret1.SetPixel(i * 2 + 1, j, CharToColor(biale2[0][1]));
                            imgSekret2.SetPixel(i * 2, j, CharToColor(biale2[0][2]));
                            imgSekret2.SetPixel(i * 2 + 1, j, CharToColor(biale2[0][3]));
                        }
                        else
                        {
                            imgSekret1.SetPixel(i * 2, j, CharToColor(biale2[1][0]));
                            imgSekret1.SetPixel(i * 2 + 1, j, CharToColor(biale2[1][1]));
                            imgSekret2.SetPixel(i * 2, j, CharToColor(biale2[1][2]));
                            imgSekret2.SetPixel(i * 2 + 1, j, CharToColor(biale2[1][3]));
                        }
                    }
                    else if (IsSameColor(temp, Color.Black))
                    {
                        if (pom == 0)
                        {
                            imgSekret1.SetPixel(i * 2, j, CharToColor(czarne2[0][0]));
                            imgSekret1.SetPixel(i * 2 + 1, j, CharToColor(czarne2[0][1]));
                            imgSekret2.SetPixel(i * 2, j, CharToColor(czarne2[0][2]));
                            imgSekret2.SetPixel(i * 2 + 1, j, CharToColor(czarne2[0][3]));
                        }
                        else
                        {
                            imgSekret1.SetPixel(i * 2, j, CharToColor(czarne2[1][0]));
                            imgSekret1.SetPixel(i * 2 + 1, j, CharToColor(czarne2[1][1]));
                            imgSekret2.SetPixel(i * 2, j, CharToColor(czarne2[1][2]));
                            imgSekret2.SetPixel(i * 2 + 1, j, CharToColor(czarne2[1][3]));
                        }

                    }
                }
            }

            result[0] = imgSekret1;
            result[1] = imgSekret2;
            return result;
        }

        private void SetPixels4(ref Bitmap bmp1, ref Bitmap bmp2, int x, int y, string colors)
        {
            bmp1.SetPixel(x * 2, y * 2, CharToColor(colors[0]));
            bmp1.SetPixel(x * 2 + 1, y * 2, CharToColor(colors[1]));
            bmp1.SetPixel(x * 2, y * 2 + 1, CharToColor(colors[2]));
            bmp1.SetPixel(x * 2 + 1, y * 2 + 1, CharToColor(colors[3]));
            bmp2.SetPixel(x * 2, y * 2, CharToColor(colors[4]));
            bmp2.SetPixel(x * 2 + 1, y * 2, CharToColor(colors[5]));
            bmp2.SetPixel(x * 2, y * 2 + 1, CharToColor(colors[6]));
            bmp2.SetPixel(x * 2 + 1, y * 2 + 1, CharToColor(colors[7]));
        }

        public Bitmap[] Create_4(string path)
        {
            Bitmap[] result = new Bitmap[2];
            Bitmap img = new Bitmap(path);
            Random rng = new Random();
            Bitmap imgSekret1 = new Bitmap(img.Width * 2, img.Height * 2);
            Bitmap imgSekret2 = new Bitmap(img.Width * 2, img.Height * 2);
            Color temp;
            int pom;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    pom = rng.Next(0, 6);
                    temp = img.GetPixel(i, j);
                    if ((int)temp.R < 128 && (int)temp.G < 128 && (int)temp.B < 128)
                    {
                        temp = Color.Black;
                    }
                    else
                    {
                        temp = Color.White;
                    }
                    if (IsSameColor(temp, Color.White))
                    {
                        if (pom == 0)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, biale4[0]);
                        }
                        else if (pom == 1)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, biale4[1]);
                        }

                        else if (pom == 2)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, biale4[2]);
                        }

                        else if (pom == 3)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, biale4[3]);
                        }

                        else if (pom == 4)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, biale4[4]);
                        }

                        else if (pom == 5)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, biale4[5]);
                        }
                    }
                    else if (IsSameColor(temp, Color.Black))
                    {
                        if (pom == 0)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, czarne4[0]);
                        }
                        else if (pom == 1)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, czarne4[1]);
                        }

                        else if (pom == 2)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, czarne4[2]);
                        }

                        else if (pom == 3)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, czarne4[3]);
                        }

                        else if (pom == 4)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, czarne4[4]);
                        }

                        else if (pom == 5)
                        {
                            SetPixels4(ref imgSekret1, ref imgSekret2, i, j, czarne4[5]);
                        }

                    }
                }
            }

            result[0] = imgSekret1;
            result[1] = imgSekret2;
            return result;
        }

        public Tuple<string, Bitmap> Recreate(string path1, string path2)
        {
            Bitmap[] source = new Bitmap[2];
            source[0] = new Bitmap(path1);
            source[1] = new Bitmap(path2);


            int x = source[0].Width;
            int y = source[0].Height;

            if(source[0].Width != source[1].Width || source[0].Height != source[1].Height)
            {
                return new Tuple<string, Bitmap>("Images are not same size!", null);
            }

            Bitmap result = new Bitmap(x, y, PixelFormat.Format24bppRgb);

            for (int i = 0; i < y; i++)
            {
                for (int k = 0; k < x; k++)
                {
                    if(IsPixelBlack(source[0].GetPixel(k,i)) || IsPixelBlack(source[1].GetPixel(k, i)))
                    {
                        result.SetPixel(k, i, Color.Black);
                    }
                    else
                    {
                        result.SetPixel(k, i, Color.White);
                    }
                }
            }

            return new Tuple<string, Bitmap>(null, result);
        }

    }


}
