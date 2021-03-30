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
        public readonly ulong[] voices;

        public Statistics(int electorate, int candidates)
        {
            this.electorate = electorate;
            this.candidates = candidates;
            voices = new ulong[this.candidates];
        }

        private ulong CalculateVoicePerDay()
        {
            ulong result = 0;
            for (var i = 0; i < candidates; i++)
            {
                result += voices[i];
            }

            return result;
        }

        private float[] calculate_and_get_percents()
        {
            var totalVoices = CalculateVoicePerDay();
            var percents = new float[candidates];
            for (var i = 0; i < candidates; i++)
            {
                if (voices != null) percents[i] = voices[i] * totalVoices / 100;
            }

            return percents;
        }

        public void get_winner()
        {
            var percents = calculate_and_get_percents();
            var winnerPercent = percents.Max();
            var winner = Array.IndexOf(percents, winnerPercent);

            Console.WriteLine("Winner-" + winnerPercent + " with " + winnerPercent + " %");
        }
    }
}