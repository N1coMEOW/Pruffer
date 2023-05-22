using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUFF
{
    internal class Decoding
    {
        public string path1 = "decod.txt";
        public string path2 = "codepruff.txt";
        public void Action(int AmCode)
        {
            List<int> Code = new List<int>();
            List<int> Peaks = new List<int>();
            List<string> Ribs = new List<string>();
            string[] arr = new string[1];
            string[] spl = new string[AmCode];
            arr = File.ReadAllLines(path2);
            spl = arr[0].Split(' ');
            for (int i = 0; i < AmCode + 2; i++)
            {
                Peaks.Add(i + 1);
            }
            for (int i = 0; i < spl.Length; i++)
            {
                Code.Add(Convert.ToInt32(spl[i]));
            }
            int index = 0;
            int min;
            int LastCode = Code[Code.Count - 1];
            int LastPeak = Peaks[Peaks.Count - 1];
            for (int i = 0; i < Code.Count; i++)
            {
                min = 10000;
                for (int j = 0; j < Peaks.Count; j++)
                {
                    if ((Peaks[j] != Code[i]) && (Peaks[j] < min) && (Peaks[j] != 0))
                    {
                        if (Code.Contains(Peaks[j]) == false)
                        {
                            min = Peaks[j];
                            index = j;
                        }
                    }
                }
                Ribs.Add($"{Code[i]} {min}");
                Peaks[index] = 0;
                Code[i] = 0;
            }
            Ribs.Add($"{LastCode} {LastPeak}");
            foreach (string s in Ribs)
            {
                Console.WriteLine(s);
                //File.AppendAllText(path1, s + "\n");
            }
        }
    }
}
