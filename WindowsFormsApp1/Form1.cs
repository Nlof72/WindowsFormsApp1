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
        double[] stats;
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
            election = new Election(
                (int)CandidatesInp.Value,
                (int)ConditionsInp.Value,
                activePeople.GetActivePeople()
                );
            timer1.Start();
            chart1.Series.Clear();
            for (int i = 0; i < (int)CandidatesInp.Value; i++)
            {
                chart1.Series.Add("Candidate "+ i);
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }

            election.Run();

            //stats = election.voices;
        }

        private void CurrentLifeInp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            //int i;

            //for (int ii = 0; ii < election.statistics.candidates; ii++)
            //{
            //    if (j <= 23) { i = rand.Next((int)Math.Round(stats[ii])); }
            //    else
            //    {
            //        i = (int)Math.Round(stats[ii]); timer1.Stop();
            //    }
            //    chart1.Series[ii].Points.AddXY(j, i);
            //}
            //election.statistics.electorate -= i;
            //PopulationInp.Value = election.statistics.electorate;

            j++;
            int[] arr1 = election.statistics.Step(election.candidates);
            for (int i = 0; i < arr1.Length; i++)
            {
                //Console.WriteLine(" час" + j + " " + arr1[i]);
                chart1.Series[i].Points.AddXY(j, arr1[i]);
            }
            if (j == 24) { 
                timer1.Stop();
                //Console.WriteLine(activePeople.ChangePopulation(PopulationInp.Value));
                PopulationInp.Value = activePeople.ChangePopulation(PopulationInp.Value);
            }
        }
    }
}
