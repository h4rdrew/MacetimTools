using System;
using System.IO;
using System.Reflection;

namespace MacetimTools.Class
{
    public static class ContentLoading
    {
        // A função ReadResource() lê os arquivos .PNG embedded
        // e cria na pasta específica, caso já esteja criado, apenas retorna.
        public static void ReadResource()
        {
            string[] packPNG = { "001.png", "002.png", "003.png",
                                 "004.png", "005.png", "006.png",
                                 "007.png", "008.png", "009.png",
                                 "010.png", "011.png", "012.png",
                                 "013.png", "014.png", "015.png",
                                 "016.png"};

            foreach (string imgPNG in packPNG)
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"MacetimTools.Content.{imgPNG}");
                try
                {
                    FileStream fileStream = new FileStream($@"C:\Program Files\Macetim\True\{imgPNG}", FileMode.CreateNew);
                    for (int i = 0; i < stream.Length; i++)
                        fileStream.WriteByte((byte)stream.ReadByte());
                    fileStream.Close();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}
