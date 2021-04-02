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
        int countElection = 0;
        string[] stata;
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if ((int)CurrentLifeInp.Value > (int)LifeLevInp.Value) { OutPutBox.Text = "Curent life level should be less then wish level"; return; }
            stata = new string[2];
            OutPutBox.Clear();
            OutPutBox.Text = (++countElection) + " Election\n\n";
            j = 0;
            activePeople = new ActivePeople((int)CurrentLifeInp.Value, (int)LifeLevInp.Value, (int)PopulationInp.Value);
            activePeople.CalcActive();
            election = new Election((int)CandidatesInp.Value, (int)ConditionsInp.Value, activePeople.GetActivePeople());
            CandidatesInp.Enabled = false;
            PopulationInp.Enabled = false;
            ConditionsInp.Enabled = false;
            LifeLevInp.Enabled = false;
            CurrentLifeInp.Enabled = false;
            timer1.Start();
            chart1.Series.Clear();
            for (int i = 0; i < (int)CandidatesInp.Value; i++)
            {
                chart1.Series.Add("Candidate "+ (i+1));
                chart1.Series[i].BorderWidth = 4;
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[i].Points.AddXY(i, 0);
            }

            election.Run();
            //for(int i = 0; i< (int)CandidatesInp.Value;i++)
            //    Console.WriteLine(election.statistics.FinalVoices[i]+"kkkkkk");
            Start.Enabled = false;
            //countElection++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stata[0] = null;
            j++;
            election.statistics.Step();
            //decimal[] totalPerHour = 
            stata[0] += j + " hour \n" ;
            float[] persentPerHour = election.statistics.ConvertToPercent();
            string str = "";
            //OutPutBox.Text += stata[0];

            for (int i = 0; i < persentPerHour.Length; i++)
            {
                chart1.Series[i].Points.Clear();
                chart1.Series[i].Points.AddXY(i, persentPerHour[i]);
                //Console.WriteLine(Math.Round(totalPerHour[i] /activePeople.GetActivePeople() *100,2));              
                stata[0] += "Condidate number - "+(i+1) + "\nVoice percent: "+ Math.Round(persentPerHour[i],2)+"% \n";

            }
            if (j == 24) { 
                timer1.Stop();
                PopulationInp.Value = activePeople.ChangePopulation(PopulationInp.Value);
                CurrentLifeInp.Value +=  activePeople.ChangeLifeLevel();
                Start.Enabled = true;

                int t = election.ChoseWinner(activePeople.difference);
                str += "\n\n----Summary----\n\n";
                str += "\nTurnout is " + activePeople.turnout * 100 + "%\n";
                if (t == 0) {
                    CandidatesInp.Value = election.ReElection();
                    str += "Need RE-Election!!!!!";
                    //Console.WriteLine("RE-Election!!!!!");

                }
                else {
                    str += "Candidate " + t + " is winner!!!!";
                    //Console.WriteLine("Candidate " + t + " is winner!!!!");
                    CandidatesInp.Enabled = true;
                }
                
            }
            OutPutBox.Text += stata[0];
            OutPutBox.Text +=str;

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            CandidatesInp.Enabled = true;
            PopulationInp.Enabled = true;
            ConditionsInp.Enabled = true;
            LifeLevInp.Enabled = true;
            CurrentLifeInp.Enabled = true;
            countElection = 0;
        }
    }
}
