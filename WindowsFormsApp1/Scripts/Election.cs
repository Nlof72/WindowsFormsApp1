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
        public readonly Statistics statistics;


        public Election(int Candidates, int Condition, decimal electorat)
        {
            statistics = new Statistics(electorat, candidates, duration);
        }

        public void Run()
        {
            statistics.GenerateSeq();
        }
    }
}

