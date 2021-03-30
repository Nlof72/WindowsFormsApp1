using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Scripts;

namespace WindowsFormsApp1
{
    class Election
    {
        private readonly int MistakeLevel;
        private readonly int Condition;

        public readonly Statistics statistics;
        Random random = new Random();
        List<float> statistics1 = new List<float>();
        public double[] voices;
        private int duration;


        public Election(int Candidates, int mistakeLevel, int Condition, int electorat)
        {
            statistics = new Statistics(electorat, Candidates, duration);
            MistakeLevel = mistakeLevel;
            this.Condition = Condition;
            voices = new double[statistics.candidates];
        }

        //public double NextGaussian(Random r, double mean = 0, double stdDev = 1)
        //{
        //    var u1 = random.Next(0, Candidates);
        //    var u2 = random.Next(0, Candidates);

        //    var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
        //                          Math.Sin(2.0 * Math.PI * u2);

        //    var rand_normal = mean + stdDev * rand_std_normal;

        //    return rand_normal;
        //}


        void GenerateSeq()
        {
            int n = 1000;
            if (statistics.candidates >= 5)
                for (int i = 0; i < statistics.candidates - 1; i++)
                {
                    //Console.WriteLine(random.NextDouble()*100);
                    int a = random.Next(0, n - n / 3);
                    Console.WriteLine((float)a / 10 + " " + i);
                    n -= a;
                    //statistics[i] = (float)a / 10;
                    statistics1.Add((float)a / 10);
                }
            else
            {
                for (var i = 0; i < statistics.candidates - 1; i++)
                {
                    //Console.WriteLine(random.NextDouble()*100);
                    var a = random.Next(0, n);
                    Console.WriteLine((float) a / 10 + " " + i);
                    n -= a;
                    //statistics[i] = (float)a / 10;
                    statistics1.Add((float) a / 10);
                }
            }
            Console.WriteLine((float)n / 10 + " " + (statistics.candidates - 1));
            //statistics[statistics.candidates -1] = (float)n / 10;
            statistics1.Add((float)n / 10);
            float[] arr = statistics1.ToArray();
            for (int i = statistics.candidates - 1; i >= 0; i--)
            {
                Random r = new Random();
                int a, b;
                float c;
                a = random.Next(0, statistics.candidates);
                b = r.Next(0, statistics.candidates);
                c = arr[a];
                arr[a] = arr[b];
                arr[b] = c;
            }
        }

        public void Run()
        {
            GenerateSeq();

            float[] arr = statistics1.ToArray();
            for(int i =0; i < statistics.candidates; i++)
            {
                voices[i] = arr[i] * statistics.electorate / 100;
            }
            int q = 0;
            foreach (var a in voices)
            {
                q+= (int)Math.Round(a);
                Console.WriteLine(Math.Round(a));
            }
            Console.WriteLine(q + " " + statistics.electorate);
        }
    }
}

