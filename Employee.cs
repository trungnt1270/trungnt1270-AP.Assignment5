using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM5
{
    abstract class Employee
    {
        public Employee()
        {

        }
        public Employee(string ssn, string firstName, string lastname, DateTime birthDate, string phone, string email)
        {
            this.SSN = ssn;
            this.FirstName = firstName;
            this.LastName = lastname;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
        }

        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual void Display()
        {
            Console.WriteLine($"{SSN}\t {FirstName} {LastName}\t" + BirthDate.ToString("dd-MM-yyyy") + $"\tphone:{Phone}\t\t{Email}");
        }
        public abstract override string ToString();
    }
}
