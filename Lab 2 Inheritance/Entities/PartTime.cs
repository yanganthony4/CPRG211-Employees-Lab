using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;
        public double Rate { get { return rate; } }
        public double Hours { get { return hours; } }

        public PartTime(string id, string name, string address, double rate, double hours)
        {
            this.id = id; // OR base.id works too
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hours = hours;
        }

        public override double CalcWeeklyPay()
        {
            double weeklyPay = 0;

            weeklyPay = this.rate * this.hours;

            return weeklyPay;
        }
    }
}
