using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace VCAEngine
{
    class VCAEngine
    {
        private readonly string White2Template = "01011010";
        private readonly string Black2Template = "00111100";

        private readonly string White4Template = "001100111100110001010101101010100110011010011001";
        private readonly string Black4Template = "100101100110100100111100110000110101101010100101";

        private bool IsPixelBlack(Color color)
        {
            if ((int)color.R < 128 && (int)color.G < 128 && (int)color.B < 128) return true;
            else return false;
        }

        private string GetBlack2Temp()
        {
            Random rand = new Random();
            return Black2Template.Substring(rand.Next(0, 2) * 4, 4);
        }

        private string GetWhite2Temp()
        {
            Random rand = new Random();
            return White2Template.Substring(rand.Next(0, 2) * 4, 4);
        }

        private string GetBlack4Temp()
        {
            Random rand = new Random();
            return Black4Template.Substring(rand.Next(0, 6) * 8, 8);
        }

        private string GetWhite4Temp()
        {
            Random rand = new Random();
            return White4Template.Substring(rand.Next(0, 6) * 8, 8);
        }

        private Color GetColorFromChar(char a)
        {
            if (a.Equals('0')) return Color.FromArgb(255, 255, 255, 255);
            else return Color.FromArgb(0, 0, 0, 0);
        }

        private void Set2Color(ref Bitmap bitmap, int x, int y, string temp)
        {
            bitmap.SetPixel(x, y, GetColorFromChar(temp[0]));
            bitmap.SetPixel(x+1, y, GetColorFromChar(temp[1]));

        }

        private void Set4Color(ref Bitmap bitmap, int x, int y, string temp)
        {
            bitmap.SetPixel(x, y, GetColorFromChar(temp[0]));
            bitmap.SetPixel(x + 1, y, GetColorFromChar(temp[1]));

            bitmap.SetPixel(x, y + 1, GetColorFromChar(temp[2]));
            bitmap.SetPixel(x + 1, y + 1, GetColorFromChar(temp[3]));
        }

        public Bitmap[] Create_2(string path)
        {
            Bitmap[] result = new Bitmap[2];
            Bitmap source = new Bitmap(path);
            int x = source.Width;
            int y = source.Height;

            result[0] = new Bitmap(2 * x, y, PixelFormat.Format24bppRgb);
            result[1] = new Bitmap(2 * x, y, PixelFormat.Format24bppRgb);

            for(int i=0; i<y; i++)
            {
                for(int k=0; k<x; k++)
                {
                    string temp;
                    if (IsPixelBlack(source.GetPixel(k, i))) temp = GetBlack2Temp();
                    else temp = GetWhite2Temp();

                    Set2Color(ref result[0], k*2, i, temp.Substring(0, 2));
                    Set2Color(ref result[1], k*2, i, temp.Substring(2, 2));
                }
            }

            return result;
        }

        public Bitmap[] Create_4(string path)
        {
            Bitmap[] result = new Bitmap[2];
            Bitmap source = new Bitmap(path);
            int x = source.Width;
            int y = source.Height;

            result[0] = new Bitmap(2 * x, 2 * y, PixelFormat.Format24bppRgb);
            result[1] = new Bitmap(2 * x, 2 * y, PixelFormat.Format24bppRgb);

            for (int i = 0; i < y; i++)
            {
                for (int k = 0; k < x; k++)
                {
                    string temp;
                    if (IsPixelBlack(source.GetPixel(k, i))) temp = GetBlack4Temp();
                    else temp = GetWhite4Temp();

                    Set4Color(ref result[0], k * 2, i * 2, temp.Substring(0, 4));
                    Set4Color(ref result[1], k * 2, i * 2, temp.Substring(4, 4));
                }
            }

            return result;
        }

        public Bitmap Recreate(string path1, string path2)
        {
            Bitmap[] source = new Bitmap[2];
            source[0] = new Bitmap(path1);
            source[1] = new Bitmap(path2);

            int x = source[0].Width;
            int y = source[0].Height;

            Bitmap result = new Bitmap(x, y, PixelFormat.Format24bppRgb);

            for (int i = 0; i < y; i++)
            {
                for (int k = 0; k < x; k++)
                {
                    if(IsPixelBlack(source[0].GetPixel(k,i)) || IsPixelBlack(source[1].GetPixel(k, i)))
                    {
                        result.SetPixel(k, i, GetColorFromChar('1'));
                    }
                    else
                    {
                        result.SetPixel(k, i, GetColorFromChar('0'));
                    }
                }
            }

            return result;
        }

    }


}
