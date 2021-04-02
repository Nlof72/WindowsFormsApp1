using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Election election;
        ActivePeople activePeople;
        int j = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            j = 0;
            activePeople = new ActivePeople((int)CurrentLifeInp.Value, (int)LifeLevInp.Value, (int)PopulationInp.Value);
            activePeople.CalcActive();
            election = new Election((int)CandidatesInp.Value, (int)ConditionsInp.Value, activePeople.GetActivePeople());
            timer1.Start();
            chart1.Series.Clear();
            for (int i = 0; i < (int)CandidatesInp.Value; i++)
            {
                chart1.Series.Add("Candidate "+ i);
                chart1.Series[i].BorderWidth = 4;
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[i].Points.AddXY(i, 0);

            }

            election.Run();
            for(int i = 0; i< (int)CandidatesInp.Value;i++)
                Console.WriteLine(election.statistics.FinalVoices[i]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            j++;
            decimal[] totalPerHour = election.statistics.Step();
            for (int i = 0; i < totalPerHour.Length; i++)
            {
                chart1.Series[i].Points.Clear();
                chart1.Series[i].Points.AddXY(i, totalPerHour[i]/activePeople.GetActivePeople()*100);
            }
            if (j == 24) { 
                timer1.Stop();
                PopulationInp.Value = activePeople.ChangePopulation(PopulationInp.Value);

            }
        }
    }
}
