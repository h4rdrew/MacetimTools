using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MacetimTools.Class
{
    class SpecificPrint
    {
        public static void printpoint()
        {
            int x1 = 478;
            int x2 = 623;
            int[] y = new int[8];
            int aux = 131;
            string[] nameImage = new string[8];

            for (int i = 0; i < 8; i++)
            {
                nameImage[i] = $"digital_{i}";
            }

            for (int b = 0; b < 4; b++)
            {
                aux = aux + 144;
                y[b] = aux;

                Rectangle rect = new Rectangle(x1, y[b], 110, 110);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                string path = @"Macetim\Temp\";
                var fileInfo = new FileInfo(path);
                if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();

                bmp.Save($@"Macetim\Temp\{nameImage[b]}.bmp", ImageFormat.Bmp);
            }

            aux = 131;

            for (int b = 4; b < 8; b++)
            {
                aux = aux + 144;
                y[b] = aux;

                Rectangle rect = new Rectangle(x2, y[b], 110, 110);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                bmp.Save($@"Macetim\Temp\{nameImage[b]}.bmp", ImageFormat.Bmp);
            }
            
        }
    }
}