using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM5
{
    class HourlyEmployee : Employee
    {
        public HourlyEmployee()
        {

        }
        public HourlyEmployee(double wage, double workingHour, string ssn, string firstName, string lastname, DateTime birthDate, string phone, string email) : base(ssn, firstName, lastname, birthDate, phone, email)
        {
            Wage = wage;
            WorkingHour = workingHour;
        }
        public double Wage { get; set; }
        public double WorkingHour { get; set; }

        public override string ToString()
        {
            return SSN + "\t\t" + FirstName + "\t\t\t" + LastName + "\t\t" +
                    BirthDate.ToString("dd-MM-yyyy") + "\t\t" + Phone + "\t\t" + Email + "\t\t\t" + 
                    Wage + "\t\t" + WorkingHour;
        }
    }
}
