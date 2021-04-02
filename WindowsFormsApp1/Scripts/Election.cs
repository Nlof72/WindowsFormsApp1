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
        private readonly int totalVoices;
        private readonly int fakeVoices;
        int condition;
        public readonly Statistics statistics;


        public Election(int Candidates, int Condition, decimal electorat)
        {
            statistics = new Statistics(electorat, Candidates);
            condition = Condition;
        }

        public void Run()
        {
            statistics.GenerateSeq();
        }
        public int ReElection()
        {
            float[] voice = statistics.ConvertToPercent();
            int y = 0;
            for (int i = 0; i < voice.Length; i++)
            {
                if (voice[i] >= 20) { y++; }
            }
            return y;
        }

        public int ChoseWinner(float turnout)
        {
            float[] voice = statistics.ConvertToPercent();
            if (turnout * 100 < (float)condition || statistics.FakeVoices >= 10) return 0;
            for (int i = 0; i< voice.Length; i++)
            {
                if (voice[i] > 50) { return i + 1; }
            }
            return 0;
        }
    }
}

