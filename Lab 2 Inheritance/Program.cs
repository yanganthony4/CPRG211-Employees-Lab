using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees= new List<Employee>();
            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] cells = line.Split(':');

                string id = cells[0];
                string name = cells[1];
                string address = cells[2];

                string firstDigit = id.Substring(0, 1);

                int firstDigitInt = int.Parse(firstDigit);

                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    string salary = cells[7];

                    double salaryDouble = double.Parse(salary);

                    Salaried salaried = new Salaried(id, name, address, salaryDouble);
                    employees.Add(salaried);
                }
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    Wages wages = new Wages(id, name, address, rateDouble, hoursDouble);
                    employees.Add(wages);
                }
                else if ((firstDigitInt >= 8 && firstDigitInt <= 9))
                {
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    PartTime partTime = new PartTime(id, name, address, rateDouble, hoursDouble);
                    employees.Add(partTime);
                }

            }
            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
                {
                    double weeklyPay = employee.CalcWeeklyPay();

                    weeklyPaySum += weeklyPay;
                }
            double averageWeeklyPay = weeklyPaySum / employees.Count;

            Console.WriteLine("Average weekly pay: " + averageWeeklyPay);

            Wages highestPaidWages = null;

            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    Wages wages = (Wages)employee;

                    if (highestPaidWages == null || wages.CalcWeeklyPay() > highestPaidWages.CalcWeeklyPay()) 
                    {
                        highestPaidWages = wages;
                    }
                } 
            }

            Console.WriteLine("\nEmployee " + highestPaidWages.Name + " is the highest paid ($" + highestPaidWages.CalcWeeklyPay() + ")");

            Salaried lowestPaidSalaried = null;

            foreach (Employee employee in employees) 
            {
                if (employee is Salaried)
                {
                    Salaried salaried = (Salaried)employee;

                    if (lowestPaidSalaried == null || salaried.CalcWeeklyPay() < lowestPaidSalaried.CalcWeeklyPay())
                    {
                        lowestPaidSalaried = salaried;
                    }
                }
            }

            Console.WriteLine("\nEmployee " + lowestPaidSalaried.Name + " is the lowest paid ($" + lowestPaidSalaried.CalcWeeklyPay() + ")");

            double wagesCount = 0;
            double salariedCount = 0;
            double parttimeCount = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    salariedCount+= 1;
                }
                else if (employee is Wages)
                {
                    wagesCount+= 1;
                }
                else if (employee is PartTime)
                {
                    parttimeCount+= 1;
                }
            }

            Console.WriteLine("\nSalaried Employees: " + salariedCount + "/" + employees.Count + "(" + (salariedCount/employees.Count * 100) + "%)" );
            Console.WriteLine("Waged Employees: " + wagesCount + "/" + employees.Count + "(" + (wagesCount / employees.Count * 100) + "%)");
            Console.WriteLine("Part-Time Employees: " + parttimeCount + "/" + employees.Count + "(" + (parttimeCount / employees.Count * 100) + "%)");

        }

                //if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4")

                //string rate = cells[7];
                //string hours = cells[8];
      
        
    }
}
