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
        public readonly int MistakeLevel;
        public readonly int Condition;
        public int electionDuration = 24;
        public readonly Statistics statistics;
        Random random = new Random();
        List<float> statistics1 = new List<float>();


        public Election(int Candidates, int mistakeLevel, int Condition, int electorat)
        {
            statistics = new Statistics(electorat, Candidates);
            this.MistakeLevel = mistakeLevel;
            this.Condition = Condition;
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
            statistics1 = arr.ToList<float>();
            double[] voices = new double[statistics.candidates];
            arr = statistics1.ToArray();
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

    //public class ZRandom
    //{
    //    private Random _random = new Random();
    //    private double _z1 = double.NegativeInfinity;

    //    public double Next()
    //    {
    //        double result;
    //        if (!double.IsNegativeInfinity(_z1))
    //        {
    //            result = _z1;
    //            _z1 = double.NegativeInfinity;
    //        }
    //        else
    //        {
    //            double x, y, s;
    //            do
    //            {
    //                x = _random.NextDouble() * 2 - 1;
    //                y = _random.NextDouble() * 2 - 1;
    //                s = x * x + y * y;
    //            } while (s <= 0 || s > 1);

    //            result = x * Math.Sqrt(-2.0 * Math.Log(s) / s);
    //            _z1 = y * Math.Sqrt(-2.0 * Math.Log(s) / s);
    //        }
    //        return result;
    //    }

    //    public double Next(double mean, double stddev)
    //    {
    //        return Next() * stddev + mean;
    //    }
    //}
    //class MainClass
    //{
    //    public static double NextGaussian(Random r, double mu = 0, double sigma = 1)
    //    {
    //        var u1 = r.NextDouble();
    //        var u2 = r.NextDouble();

    //        var rand_std_normal = Math.Sqrt(-1.0 * Math.Log(u1)) *
    //                            Math.Sin(5.0 * Math.PI * u2);

    //        var rand_normal = mu + sigma * rand_std_normal;

    //        return rand_normal;
    //    }

    //    public static void Main(string[] args)
    //    {
    //        int max = int.MinValue;
    //        int min = int.MaxValue;
    //        int r;
    //        int N = 5;
    //        int[] k = new int[N];
    //        Random rand_normal = new Random();
    //        Random ra = new Random();
    //        for (int i = 0; i <= 100000; i++)
    //        {

    //            r = Math.Abs(((int)NextGaussian(rand_normal, 2, ra.NextDouble() * N)) % N);
    //            if (r >= max) max = r;
    //            if (r <= min) min = r;

    //            k[r]++;
    //        }
    //        Console.WriteLine("Min: " + min + "Max: " + max);
    //        for (int a = 0; a < N; a++)
    //        {
    //            Console.WriteLine(a + "-" + k[a]);
    //        }
    //        Console.WriteLine(k.Max());
    //    }
    //}
}


/*class Statistic(object):
def __init__(self, amount_people, kandidates, selection_type):
    #количество людей,которые должны были придт
    self.total_amount = amount_people
    #массив кандидатов проголосовавших за каждого кандидата
    self.kandidates = kandidates
    #тип выборов
    self.selection_type = selection_type

    def calculate_voices_due_day(self):
        result=0
        for i in self.kandidates:
            result +=i
        return result

    def calculate_and_get_percents(self):
        total_voices = self.calculate_voices_due_day()
        percents=[]
        for kandidate_voices in self.kandidates:
            # (a*b/100) - percent of kandidate
            percents.append(total_voices*kandidate_voices/100)
        return percent

    def get_winner(self):
        percents = self.calculate_and_get_percents()
        winner_percent = max(percents)
        winner = percents.index(winner_percent)

        print("The winner is %s,percent is %s").format(winner,winner percent)
*/