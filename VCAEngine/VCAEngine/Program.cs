using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace VCAEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Bartolomeo\\Desktop\\GitHub\\VisualCryptographyApp\\Examples\\binary.bmp";

            string pathA = "C:\\Users\\Bartolomeo\\Desktop\\GitHub\\VisualCryptographyApp\\Examples\\binaryA.bmp";
            string pathB = "C:\\Users\\Bartolomeo\\Desktop\\GitHub\\VisualCryptographyApp\\Examples\\binaryB.bmp";

            string pathEND = "C:\\Users\\Bartolomeo\\Desktop\\GitHub\\VisualCryptographyApp\\Examples\\binaryEND.bmp";

            VCAEngine engine = new VCAEngine();

            var result = engine.Create_2(path);
            result[0].Save(pathA, ImageFormat.Bmp);
            result[1].Save(pathB, ImageFormat.Bmp);

            var result2 = engine.Recreate_2(pathA, pathB);

            result2.Save(pathEND, ImageFormat.Bmp);


        }
    }
}
