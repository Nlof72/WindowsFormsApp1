using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ActivePeople
    {
        int currentLife;
        int lifelev;
        decimal activePopulation;
        public float difference;
        public float turnout;
        public ActivePeople(int CurrentLife, int Lifelev , decimal activePopulation) {
            this.currentLife = CurrentLife;
            this.lifelev = Lifelev;
            this.activePopulation = activePopulation;
        }
        void CalcActivePeople()
        {

            activePopulation = Math.Round(activePopulation * (decimal)difference);
            Console.WriteLine(activePopulation+" Active Population");
        }

        public void CalcActive() {
            //Console.WriteLine(GetProcent(lifelev*100,Math.Abs(currentLife-10)*100,1000)+" --------------");
            turnout = GetProcent(lifelev * 100, (Math.Abs(currentLife - lifelev)<5?5:Math.Abs(currentLife - lifelev)) * 100, 1000);
            difference = turnout;
            //if (difference == 0) { difference = 0.5f; }
            CalcActivePeople();
            //return difference;
            //Улучшить рандом
        }

        float GetProcent(int right, int left = 0, float n = 10)
        {
            Random r = new Random();
            //Console.WriteLine(r.Next(left, rigt) / n);
            return r.Next(left, right) / n;
        }
        public decimal ChangePopulation( decimal Population)
        {
            //int n = 100;
            decimal d = Math.Round(Population + (decimal)(GetProcent(100) -5)* Population / 100);
            //Console.WriteLine("Was :"+Population+" Become :" + d);
            return d;
        }

        public decimal ChangeLifeLevel()
        {
            decimal d =  (decimal)(GetProcent(3,0,1) -1);
            Console.WriteLine(" Become :" + d);
            if((currentLife+d> lifelev) || (currentLife+d <0)) return 0;
            if ((currentLife+d <= lifelev)||(currentLife + d>0)) return d;
            return 0;
        }
        public decimal GetActivePeople()
        {
            return activePopulation;
        }
    }
}
