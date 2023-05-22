using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUFF
{
    internal class Coding
    {
        public string path1 = "Ribs.txt";
        public string path2 = "Code.txt";
        public void Action(int AmRibs)
        {
            string[] arr = new string[AmRibs];
            string[] spl = new string[2];
            arr = File.ReadAllLines(path1);
            List<int> Ribsu = new List<int>();
            List<int> Ribsd = new List<int>();
            List<int> Proof = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                spl = arr[i].Split(' ');
                Ribsu.Add(Convert.ToInt32(spl[0]));
                Ribsd.Add(Convert.ToInt32(spl[1]));
            }
            int min;
            int index = 0;
            for (int i = 0; i < Ribsd.Count - 1; i++)
            {
                min = 10000;
                for (int j = 0; j < Ribsd.Count; j++)
                {
                    if ((Ribsd[j] < min) && (Ribsu.Contains(Ribsd[j]) == false) && (Ribsd[j] != 0))
                    {
                        min = Ribsd[j];
                    }
                }
                if (Ribsu.Contains(min) == false)
                {
                    index = Ribsd.IndexOf(min);
                    Proof.Add(Ribsu[index]);
                    Ribsd[index] = 0;
                    Ribsu[index] = 0;
                }
            }
            foreach (int i in Proof)
            {
                File.AppendAllText(path2, Convert.ToString(i) + " ");
            }
        }
    }
}
