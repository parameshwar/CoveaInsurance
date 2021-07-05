using Covea.Library;
using System;
using System.Collections.Generic;

namespace Covea
{
   public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter Sum Assured\n");
                string a;
                a = Console.ReadLine();
                int sumAssured = Convert.ToInt32(a);
                Console.WriteLine("SumAssured given Input value {0}", sumAssured);
                Console.Write("Enter Age\n");
                string b;
                b = Console.ReadLine();
                int age = Convert.ToInt32(b);
                Console.WriteLine("SumAssured given Input value {0}", age);
                bool IsValid = ValidateInput(sumAssured, age);
                if (IsValid)
                {
                    InsuranceBusinessLogic insuranceBusinessLogic = new InsuranceBusinessLogic(new InsuranceDataAccess());
                    double grossPremium = insuranceBusinessLogic.CalculateGrossPremium(ref sumAssured, age);
                    Console.WriteLine("Sum Assured: {0}, Applicant Age: {1}, Gross Premium value : {2}", sumAssured, age, grossPremium);
                }
                Console.WriteLine("\n\nType yes to continue or no to exit");
                string input = Console.ReadLine();
                if(input == "no" || string.IsNullOrEmpty(input) || input != "yes")
                {
                    break;
                }
                else 
                {
                    continue;
                }
                
            }
        }

        public static bool ValidateInput(int sumAssured, int age)
        {
            string output = "";
            bool IsValid = true;
            if (sumAssured < 25000 || sumAssured > 500000 || sumAssured < 0)
            {
                output += "Invalid sum assured value. Enter SumAssured value between 25000 and 500000";
                IsValid = false;
            }
            if (age < 18 || age > 65 || age < 0)
            {
                output += "\nInvalid age value. Enter age value between 18 and 65";
                IsValid = false;
            }
            if(age > 30 && age < 50 && sumAssured > 300000)
            {
                output += "\n Invalid sum assured for given age. Maximum sum assured for age 31 to 50 is 300000";
                IsValid = false;
            }
            if(age > 50 && sumAssured > 200000)
            {
                output += "\n Invalid sum assured for given age. Maximum sum assured for age above 50 is 200000";
                IsValid = false;
            }
            Console.WriteLine("{0}", output);
            return IsValid;
        }
    }
}
