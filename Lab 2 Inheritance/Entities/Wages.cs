using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    internal class Wages : Employee
    {
        private double rate;
        private double hours;
        public double Rate { get { return rate; } }
        public double Hours { get { return hours; } }
        public Wages(string id, string name, string address, double rate, double hours)
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

            if (this.hours < 40)
            {
                weeklyPay = this.hours * this.rate;
            } 
            else
            {
                double overtimeHours = this.hours - 40;

                weeklyPay = 40 * this.rate;

                double overtimePay = overtimeHours * (this.rate * 1.5);

                weeklyPay += overtimePay;
            }

            return weeklyPay;
        }
    }
}
