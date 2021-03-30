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
            chart1.Series[0].Points.Clear();
            j = 0;
            activePeople = new ActivePeople((float)CurrentLifeInp.Value, (float)LifeLevInp.Value, (int)PopulationInp.Value);
            activePeople.CalcActive();
            election = new Election((int)CandidatesInp.Value, (int)MistakeInp.Value, (int)ConditionsInp.Value, activePeople.GetActivePeople());
            timer1.Start();
            //chart1.Series.Add("llll");
            election.Run();

        }

        private void CurrentLifeInp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
 
            Random rand = new Random();


            int i;
            if (j <= 23) { i = rand.Next(election.electorat)/5; }
            else { i = election.electorat; timer1.Stop(); 
            }
            chart1.Series[0].Points.AddXY(j,i);
            RedOutput.Text = i + "";
            election.electorat -= i;
            j++;
            PopulationInp.Value = election.electorat;
        }
    }
}
