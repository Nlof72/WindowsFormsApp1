using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Scripts
{
    public class Statistics
    {
        private int Duration;
        private int Candidates;
        public double FakeVoices;
        public decimal Electorate;
        public decimal[] VoicesPerHour;
        public decimal[] FinalVoices;

        public Statistics(decimal electorate, int candidates, int duration = 24)
        {
            Candidates = candidates;
            VoicesPerHour = new decimal[candidates];
            FinalVoices = new decimal[candidates];
            FakeVoices = 0;
            Duration = duration;
            Electorate = electorate;
        }
        public decimal[] Step()
        {
            decimal voices;
            Random random = new Random();
            if (Duration == 1)
            {
                decimal total_people = 0;
                for (int i = 0; i < Candidates; i++) { 
                    VoicesPerHour[i] += FinalVoices[i];
                }
                for (int i = 0; i < Candidates; i++)
                {
                    total_people += VoicesPerHour[i];
                }

                FakeVoices = random.Next(0, 15);
            }
            else
            {
                for (int i = 0; i < Candidates; i++)
                {
                    voices = random.Next(0, (int)(FinalVoices[i] - FinalVoices[i] / 1.2m));
                    VoicesPerHour[i] += voices;
                    FinalVoices[i] -= voices;
                }
            }
            Duration--;
            return VoicesPerHour;
        }

        void VotesDistribution(bool lessThanFive, int percents)
        {
            Random random = new Random();
            // distribution of votes to n candidates 
            for (int i = 0; i < Candidates - 1; i++)
            {
                int a;
                a = lessThanFive ? random.Next(percents / 100, percents) : random.Next(percents / 100, percents - percents / 3);
                percents -= a;
                FinalVoices[i] = (decimal)a / 10;
            }
            // the distribution of the last candidate is calculated separately
            FinalVoices[Candidates-1] = (decimal)percents / 10;
            for (int i = 0; i < Candidates; i++)
            {
                //voices[i] = arr[i] * statistics.electorate / 100;
                FinalVoices[i] = (int)Math.Round(FinalVoices[i] * Electorate / 100);
            }
        }

        public float[] ConvertToPercent()
        {
            float[] persents = new float[Candidates];
            for (int i = 0; i < Candidates; i++)
            {
                persents[i] =  (float)(VoicesPerHour[i] / Electorate * 100);
            }
            return persents;
        }

        public void GenerateSeq()
        {
            VotesDistribution(Candidates < 5, 1000);

            for (int i = Candidates - 1; i >= 0; i--)
            {
                Random r = new Random();
                Random random = new Random();
                int a = random.Next(0, Candidates);
                int b = r.Next(0, Candidates);
                decimal c = FinalVoices[a];
                FinalVoices[a] = FinalVoices[b];
                FinalVoices[b] = c;
            }

        }
    }
}
