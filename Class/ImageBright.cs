using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacetimTools.Form1;

namespace MacetimTools.Class
{
    public class ImageBright
    {
        public static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();

            Bitmap bmpMin = new Bitmap(bmpSource);

            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.1f);
                    //NÃO MEXER NA LINHA DE BAIXO PELO MAOR DE DEUS
                    if (bmpSource != null)
                    {
                        bmpSource.Dispose();
                        bmpSource = null;
                    }
                    //NÃO MEXER NA LINHA DE CIMA
                }
            }
            
            return lResult;
        }
    }
}
