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
        public Bitmap[] Create_2(string path)
        {
            Bitmap[] result = new Bitmap[2];
            Bitmap source = new Bitmap(path);
            int x = source.Width;
            int y = source.Height;


            result[0] = new Bitmap(2 * x, 2 * y, PixelFormat.Format24bppRgb);
            result[1] = new Bitmap(2 * x, 2 * y, PixelFormat.Format24bppRgb);


            return result;
        }

        public Bitmap Recreate_2(string path1, string path2)
        {
            Bitmap[] source = new Bitmap[2];
            source[0] = new Bitmap(path1);
            source[1] = new Bitmap(path2);

            int x = source[0].Width;
            int y = source[0].Height;

            Bitmap result = new Bitmap(x / 2, y / 2, PixelFormat.Format24bppRgb);


            return result;
        }

    }


}
