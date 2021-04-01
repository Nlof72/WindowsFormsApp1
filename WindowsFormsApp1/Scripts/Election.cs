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
        private readonly int thrownBilutes;
        private readonly int Condition;
        public readonly Statistics statistics;
        //public double[] voices;
        private int duration = 24;
        public int candidates;
        Random random = new Random();
        List<float> statistics1 = new List<float>();

        public Election(int Candidates, int Condition, decimal electorat)
        {
            candidates = Candidates;
            statistics = new Statistics(electorat, candidates, duration);
            thrownBilutes = mistakeLevel;
            this.Condition = Condition;
            //voices = new double[candidates];
        }

        void VotesDistribution(bool lessThanFive, int percents)
        {
            // distribution of votes to n candidates 
            for (int i = 0; i < candidates - 1; i++)
            {
                int a;
                if (lessThanFive) { a = random.Next(percents / 100, percents); }
                else { a = random.Next(percents / 100, percents - percents / 3); }
                percents -= a;
                statistics1.Add((float)a / 10);
            }
            //Console.WriteLine((float)percents / 10 + " " + (statistics.candidates - 1));

            // the distribution of the last candidate is calculated separately
            statistics1.Add((float)percents / 10);
        }
        void GenerateSeq()
        {
            if (candidates >= 5){ VotesDistribution(false, 1000); }
            else { VotesDistribution(true, 1000); }

            float[] arr = statistics1.ToArray();
            for (int i = candidates - 1; i >= 0; i--)
            {
                Random r = new Random();
                int a = random.Next(0, candidates);
                int b = r.Next(0, candidates);
                float c = arr[a];
                arr[a] = arr[b];
                arr[b] = c;
            }
        }
        
        float[] getVoices()
        {
            float[] arr = statistics1.ToArray();
            for (int i = 0; i < candidates; i++)
            {
                //voices[i] = arr[i] * statistics.electorate / 100;
                statistics.FinalVoices[i] = (int)Math.Round(arr[i] * (double)statistics.electorate / 100);
            }
            return arr;
        }

        public int getTotalVoices(float[] voices)
        {
            int q = 0;
            foreach (var a in voices)
            {
                q += (int)Math.Round(a);
                Console.WriteLine(Math.Round(a));
            }
            return q;
            //Console.WriteLine(q + " " + statistics.electorate);
        }
        public void Run()
        {
            // distribution of votes
            GenerateSeq();
            var voices = getVoices();
            var total_voices = getTotalVoices(voices);
        }
    }
}

