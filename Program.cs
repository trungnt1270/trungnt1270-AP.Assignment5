using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ASM5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<SalariedEmployee> salariedEmployees = new List<SalariedEmployee>();
            List<HourlyEmployee> hourlyEmployees = new List<HourlyEmployee>();
            int choice = 0;
            while (choice != 4)
            {
                Console.WriteLine("========== EmployeeManagement =========");
                DisplayMainMenu();
                do
                {
                    try
                    {
                        Console.Write("Enter Menu Option Number: ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (true);
                switch (choice)
                {
                    case 1:
                        DisplayImportMenu();
                        int importChocie;
                        do
                        {
                            Console.Write("Enter Menu Option Number: ");
                        } while (!int.TryParse(Console.ReadLine(), out importChocie));
                        switch (importChocie)
                        {
                            case 1:
                                SalariedEmployee salariedEmployee = new SalariedEmployee();
                                Console.WriteLine("Enter SSN: ");
                                salariedEmployee.SSN = Console.ReadLine();
                                Console.WriteLine("Enter First Name: ");
                                salariedEmployee.FirstName = Console.ReadLine();
                                Console.WriteLine("Enter last name : ");
                                salariedEmployee.LastName = Console.ReadLine();
                                salariedEmployee.BirthDate = GetBirthDate();
                                salariedEmployee.Phone = GetPhoneNumber();
                                salariedEmployee.Email = GetEmail();
                                string getBasicSalaryMsg = "Enter basic salary: ";
                                salariedEmployee.BasicSalary = GetTypeDouble(getBasicSalaryMsg);
                                string getGrossSalesMsg = "Enter gross sale : ";
                                salariedEmployee.GrossSales = GetTypeDouble(getGrossSalesMsg);
                                string getCommmissionRateMsg = "Enter commission rate : ";
                                salariedEmployee.CommmissionRate = GetTypeDouble(getCommmissionRateMsg);
                                employees.Add(salariedEmployee);
                                salariedEmployees.Add(salariedEmployee);
                                if (employees.Contains(salariedEmployee) && salariedEmployees.Contains(salariedEmployee))
                                {
                                    Console.WriteLine("Import employee successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Import employee failed!");
                                }
                                break;
                            case 2:
                                HourlyEmployee hourtyEmployee = new HourlyEmployee();
                                Console.WriteLine("Enter SSN: ");
                                hourtyEmployee.SSN = Console.ReadLine();
                                Console.WriteLine("Enter First Name: ");
                                hourtyEmployee.FirstName = Console.ReadLine();
                                Console.WriteLine("Enter last name : ");
                                hourtyEmployee.LastName = Console.ReadLine();
                                hourtyEmployee.BirthDate = GetBirthDate();
                                hourtyEmployee.Phone = GetPhoneNumber();
                                hourtyEmployee.Email = GetEmail();
                                string getWageMsg = "Enter Wage: ";
                                double wage = GetTypeDouble(getWageMsg);
                                string getWorkingHoursMsg = "Enter working hours: ";
                                double workingHours = GetTypeDouble(getWorkingHoursMsg);
                                employees.Add(hourtyEmployee);
                                hourlyEmployees.Add(hourtyEmployee);
                                if (employees.Contains(hourtyEmployee) && hourlyEmployees.Contains(hourtyEmployee))
                                {
                                    Console.WriteLine("Import employee successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Import employee failed!");
                                }

                                break;
                            case 3:

                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nList of employees general information : \n");
                        foreach (var e in employees)
                        {
                            e.Display();
                        }
                        break;
                    case 3:
                        int searchChoice = 0;
                        while (searchChoice != 3)
                        {
                            DisplaySearchMenu();
                            do
                            {
                                Console.Write("Enter Menu Option Number: ");
                            } while (!int.TryParse(Console.ReadLine(), out searchChoice));

                            switch (searchChoice)
                            {
                                case 1:
                                    Console.WriteLine("Enter Employee Type: ");
                                    string type = Console.ReadLine();
                                    if (type.ToUpper().Equals("HOURLY"))
                                    {
                                        Console.WriteLine("SSN\t\tFirstName\t\tLastName\t\tBirthDate\t\tPhone\t\tEmail\t\t\tWage\t\tWorkingHour");
                                        foreach (var e in hourlyEmployees)
                                        {
                                            Console.WriteLine(e.ToString());
                                        }
                                    }
                                    else if (type.ToUpper().Equals("SALARIED"))
                                    {
                                        Console.WriteLine("SSN\t\tFirstName\t\tLastName\t\tBirthDate\t\tPhone\t\tEmail\t\t\tCommmissionRate\t\tGrossSales\t\tBasicSalary");
                                        foreach (var e in salariedEmployees)
                                        {
                                            Console.WriteLine(e.ToString());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Type !");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Enter employee name: ");
                                    string firstName = Console.ReadLine();
                                    bool find = false;
                                    foreach (var e in employees)
                                    {
                                        if (e.FirstName.Equals(firstName))
                                        {
                                            e.Display();
                                            find = true;
                                        }
                                    }
                                    if (!find)
                                    {
                                        Console.WriteLine($"Cannot find employee name \"{firstName}\" in employees list!");
                                    }
                                    break;
                                case 3:
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice!");
                                    break;
                            }
                        }
                        break;

                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            Console.WriteLine("\nPROGRAM ENDED!");
            Console.ReadKey();
        }
        static void DisplayMainMenu()
        {
            Console.WriteLine("Please select the admin area you require:");
            Console.WriteLine("1. Import Employee.");
            Console.WriteLine("2. Display Employees Information.");
            Console.WriteLine("3. Search Employee.");
            Console.WriteLine("4. Exit.");
        }
        static void DisplayImportMenu()
        {
            Console.WriteLine("========== Import Employee ==========");
            Console.WriteLine("1. Salaried Employee.");
            Console.WriteLine("2. Hourly Employee.");
            Console.WriteLine("3. Main Menu");
        }
        static void DisplaySearchMenu()
        {
            Console.WriteLine("========== Search Employee ==========");
            Console.WriteLine("1. By Employee Type.");
            Console.WriteLine("2. By Employee Name.");
            Console.WriteLine("3. Main Menu");
        }
        static DateTime GetBirthDate()
        {
            DateTime dt;
            do
            {
                Console.WriteLine("Enter a date of birth in the format day/month/year");
                string date = Console.ReadLine();
                string pattern = @"^\d{2}\/\d{2}\/\d{4}";
                bool match = Regex.IsMatch(date, pattern);
                if (match)
                {
                    string targetDateFormat = "dd/MM/yyyy";
                    dt = DateTime.ParseExact(date, targetDateFormat, null);
                    break;
                }
                else
                {
                    Console.WriteLine("Please input date in right format (dd-MM-yyyy)");
                }
            } while (true);
            return dt;
        }
        static string GetPhoneNumber()
        {
            string phoneNumber;
            do
            {
                Console.WriteLine("Enter phone number (7 digits): ");
                phoneNumber = Console.ReadLine();
                string pattern = @"^\d{7}";
                if (Regex.IsMatch(phoneNumber, pattern))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid phone number!");
                }
            } while (true);
            return phoneNumber;
        }
        static string GetEmail()
        {
            string email;
            do
            {
                Console.WriteLine("Enter Email : ");
                email = Console.ReadLine();
                string pattern = @"^[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+$";
                if (Regex.IsMatch(email, pattern))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid email!");
                }
            } while (true);
            return email;
        }
        static double GetTypeDouble(string s)
        {
            double num;
            do
            {
                try
                {
                    Console.WriteLine(s);
                    num = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
            return num;
        }
    }
}
