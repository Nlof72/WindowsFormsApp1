using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ActivePeople
    {
        float currentLife;
        float lifelev;
        int activePopulation;
        public float difference;
        public ActivePeople(float CurrentLife, float Lifelev , int activePopulation) {
            this.currentLife = CurrentLife;
            this.lifelev = Lifelev;
            this.activePopulation = activePopulation;
        }
        void CalcActivePeople()
        {
            activePopulation = (int)Math.Round(activePopulation * difference);
        }

        public void CalcActive() {
            difference = Math.Abs(lifelev - currentLife)/10;
            if(difference == 0) { difference = 0.5f; }
            CalcActivePeople();
            //return difference;
            //Улучшить рандом
        }
        public int GetActivePeople()
        {
            return activePopulation;
        }
    }
}
