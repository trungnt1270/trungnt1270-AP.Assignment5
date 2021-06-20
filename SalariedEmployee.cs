using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM5
{
    class SalariedEmployee : Employee
    {
        public SalariedEmployee()
        {

        }
        public SalariedEmployee(double commissionRate, double grossSales, double basicSalary, string ssn, string firstName, string lastname, DateTime birthDate, string phone, string email) : base(ssn, firstName, lastname, birthDate, phone, email)
        {
            CommmissionRate = commissionRate;
            GrossSales = grossSales;
            BasicSalary = basicSalary;
        }
        public double CommmissionRate { get; set; }
        public double GrossSales { get; set; }
        public double BasicSalary { get; set; }

        public override string ToString()
        {
            return SSN + "\t\t" + FirstName + "\t\t\t" + LastName + "\t\t\t" +
                   BirthDate.ToString("dd-MM-yyyy") + "\t\t" + Phone + "\t\t" + Email + "\t\t" + 
                   CommmissionRate + "\t\t" + GrossSales +"\t\t" + BasicSalary;
        }
    }
}
