using System;
using System.IO;
using System.Collections.Generic;

namespace algorithm
{
    class Program
    {
        static uint ivc = 0;
        static uint[] data;
        
        static void Main(string[] args)
        {
            int count = ReadDataFile("IntegerArray.txt", out data);
            MergeSort(data, 0, count - 1);
            Console.WriteLine(String.Format("input count = {0}\ninversion count = {1}", count, ivc));
        }

        static void MergeSort(uint[] arr, int p, int r)
        {
            int q = 0;

            if (p < r)
            {
                q = (int)((p + r) / 2);
                MergeSort(arr, p, q);
                MergeSort(arr, q + 1, r);
                Merge(arr, p, q, r);
            }
        }

        static void Merge(uint[] arr, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;

            q++;

            uint[] L = new uint[n1 + 1];
            uint[] R = new uint[n2 + 1];

            int i = 0;
            int j = 0;

            for (i = 0; i < L.Length - 1; i++)
                L[i] = arr[p + i];
            for (j = 0; j < R.Length - 1; j++)
                R[j] = arr[q + j];

            L[n1] = uint.MaxValue;
            R[n2] = uint.MaxValue;

            i = 0; j = 0;

            for (int k = p; k <= r; k++)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                    ivc += (uint) (n1 - i);
                }
            }
        }

        static int ReadDataFile(string fname, out uint[] arr)
        {
            List<uint> list = new List<uint>();
            string[] lines = File.ReadAllLines(fname);
            
            list.Capacity = lines.Length;

            foreach (string s in lines)
                list.Add(uint.Parse(s));

            arr = list.ToArray();

            return arr.Length;
        }
    }
}

