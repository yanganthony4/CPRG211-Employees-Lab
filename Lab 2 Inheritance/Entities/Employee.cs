using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    internal class Employee
    {
        private double rate;
        private double hours;
        public double Rate { get { return rate; } }

        public double Hours { get { return hours; } }

        protected string id;
        protected string name;
        protected string address;

        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Address { get { return address; } }

        public Employee() { }

        public Employee(string id, string name, string address, double rate, double hours)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hours = hours;
        }

        public virtual double CalcWeeklyPay()
        {
            return 0;
        }
    }
}
