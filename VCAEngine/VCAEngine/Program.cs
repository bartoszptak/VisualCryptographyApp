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
            string path = "D:\\Github\\VisualCryptographyApp\\Examples\\exampleBefore.bmp";

            string pathA = "D:\\Github\\VisualCryptographyApp\\Examples\\exampleA.bmp";
            string pathB = "D:\\Github\\VisualCryptographyApp\\Examples\\exampleB.bmp";

            string pathEND = "D:\\Github\\VisualCryptographyApp\\Examples\\exampleAfter.bmp";

            VCAEngine engine = new VCAEngine();

            var result = engine.Create_4(path);
            result[0].Save(pathA, ImageFormat.Bmp);
            result[1].Save(pathB, ImageFormat.Bmp);

            var result2 = engine.Recreate(pathA, pathB);

            result2.Save(pathEND, ImageFormat.Bmp);


        }
    }
}
