using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Scripts
{
    public class Statistics
    {
        public int electorate;
        public int[] FinalVoices;
        private int ElectionDuration;
        int[] interimVoices;

        public Statistics(int electorate, int candidates, int electionDuration)
        {
            this.electorate = electorate;
            interimVoices = new int[candidates];
            ElectionDuration = electionDuration;
            FinalVoices = new int[candidates];
        }

        public int[] Step(int candidates)
        {
            int voicesPerHour;
            Random random = new Random();

            if (ElectionDuration == 0)
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
                    voicesPerHour = random.Next(0, FinalVoices[i] - (int)(FinalVoices[i] / 1.2f));
                    interimVoices[i] += voicesPerHour;
                    FinalVoices[i] -= voicesPerHour;
                }
            }

            //Console.WriteLine(CurrentTime + "DAY");
            ElectionDuration--;
            return interimVoices;
        }
    }
}