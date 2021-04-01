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
        public int FakeVoices;
        public decimal Electorate;
        public decimal[] VoicesPerHour;
        public decimal[] FinalVoices;

        public Statistics(decimal electorate, int candidates, int duration = 24)
        {
            Candidates = candidates;
            VoicesPerHour = new decimal[candidates];
            FinalVoices = new decimal[candidates];
            Duration = duration;
            Electorate = electorate;
        }
        public decimal[] Step()
        {
            decimal voices;
            Random random = new Random();
            if (Duration == 0)
            {
                for (int i = 0; i < Candidates; i++) { VoicesPerHour[i] += FinalVoices[i]; }
            }
            else
            {
                for (int i = 0; i < Candidates; i++)
                {
                    voices = random.Next(0, (int)(FinalVoices[i] - FinalVoices[i] / 1.2m));
                    VoicesPerHour[i] += voices;
                    FinalVoices[i] -= voices;
                }
                FakeVoices = random.Next(0, 1);
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
            FinalVoices[Candidates] = (decimal)percents / 10;

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
