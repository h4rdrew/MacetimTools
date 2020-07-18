using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Drawing;
using static MacetimTools.Class.ImageBright;
using System.Windows.Forms;

namespace MacetimTools.Class
{
    class ComparateImage
    {
        
        public static int[] array_public = new int[4];
        //int[] array_local = new int[4];

        public void image_comparate()
        {

            string[] filesTemp = Directory.GetFiles(@"C:\Program Files\Macetim\Temp");
            string[] filesTrue = Directory.GetFiles(@"C:\Program Files\Macetim\True");
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
            int aux = 0;
            //string teste;

            for (int count = 0; count < 16; count++)
            {
                for (int act_position = 0; act_position < 8; act_position++)
                {
                    equalElements = iHash1[count].Zip(iHash2[act_position], (i, j) => i == j).Count(eq => eq);

                    if (equalElements > 10000)
                    {
                        position = position + $" {act_position + 1}";

                        array_public[h] = act_position + 1;
                        //array_local[h] = act_position + 1;
                        h++;
                    }
                }
            }

            int caux = 3;

            for (int count = 0; count < 4; count++)
            {
                if (array_public[0] > array_public[caux])
                {
                    aux = array_public[caux];
                    array_public[caux] = array_public[0];
                    array_public[0] = aux;
                }
                caux--;
            }

            //MessageBox.Show($"pos: {array_public}");
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Configure the audio output.   
                synth.SetOutputToDefaultAudioDevice();

                // Create a PromptBuilder object and append a text string.  
                PromptBuilder song = new PromptBuilder();
                song.AppendText($"{array_public[0]} {array_public[1]} {array_public[2]} {array_public[3]}");

                // Speak the contents of the prompt synchronously.  
                synth.Speak(song);
            }

            //MessageBox.Show($"pos: {position}");
        }
    }
}
