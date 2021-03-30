using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Scripts
{
    public class Statistics
    {
        public readonly int candidates;
        public int electorate;

        public int[] FinalVoices;
        private int ElectionDuration;
        private int CurrentTime = 1;
        int[] interimVoices;

        public Statistics(int electorate, int candidates, int electionDuration)
        {
            this.electorate = electorate;
            this.candidates = candidates;
            interimVoices = new int[candidates];
            ElectionDuration = electionDuration;
        }

        public int[] Step()
        {
            int voicesPerHour;
            Random random = new Random();
            if (CurrentTime == ElectionDuration)
            {
                for (int i = 0; i < candidates; i++)
                {
                    interimVoices[i] += FinalVoices[i];
                }
            }
            else
            {
                for (int i = 0; i < candidates; i++)
                {
                    voicesPerHour = random.Next(0, FinalVoices[i] - (int)(FinalVoices[i] * 0.7));
                    interimVoices[i] += voicesPerHour;
                    FinalVoices[i] -= voicesPerHour;
                }
            }

            Console.WriteLine(CurrentTime + "DAY");
            CurrentTime++;
            return interimVoices;
        }
    }
}