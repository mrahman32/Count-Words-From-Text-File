using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CountWordsFromTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var total = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var sr = new StreamReader("D:/wap.txt"))
            {
                
                while (!sr.EndOfStream)
                {
                    var counts = sr
                        .ReadLine()
                        .Split(' ')
                        .GroupBy(s => s)
                        .Select(g => new { Word = g.Key, Count = g.Count() });
                    var wc = counts.Sum(i => i.Count);
                    total += (wc == null) ? 0 : wc;
                }
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine(total + "\n Time Required : " + elapsedTime);
            Console.ReadKey();
        }
    }
}
