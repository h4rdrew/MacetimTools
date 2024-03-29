﻿using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using static MacetimTools.Class.ImageBright;

namespace MacetimTools.Class
{
    class ComparateImage
    {
        public static List<int> numbers = new List<int>();

        public string image_comparate()
        {
            string path = @"Macetim\Temp\";
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();

            string[] filesTemp = Directory.GetFiles(@"Macetim\Temp");
            string[] filesTrue = Directory.GetFiles(@"Macetim\True");

            List<bool>[] iHash1 = new List<bool>[16];
            List<bool>[] iHash2 = new List<bool>[8];

            for (int count = 0; count < 16; count++)
            {
                iHash1[count] = GetHash(new Bitmap($@"{filesTrue[count]}"));
            }

            for (int count = 0; count < 8; count++)
            {
                iHash2[count] = GetHash(new Bitmap($@"{filesTemp[count]}"));
            }

            int equalElements = new int();
            string position = "";
            int h = 0;

            for (int count = 0; count < 16; count++)
            {
                for (int act_position = 0; act_position < 8; act_position++)
                {
                    equalElements = iHash1[count].Zip(iHash2[act_position], (i, j) => i == j).Count(eq => eq);

                    if (equalElements > 10000)
                    {
                        position = position + $" {act_position + 1}";

                        numbers.Add(act_position + 1);
                        
                        h++;
                    }
                }
            }

            List<int> sortedNumbers = numbers.OrderBy(number => number).ToList(); //Organizando os números em ordem crescente.
            string digNumber = string.Join(",", sortedNumbers.ToArray()); //Adicionando os números a uma string com a vírgula como separador.

            // Limpando as listas:
            numbers.Clear();
            sortedNumbers.Clear();

            return digNumber;
        }
    }
}
