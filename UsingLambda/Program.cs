using System;
using System.Linq;
using System.Collections.Generic;

namespace UsingLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's hire some people: \n");
            System.Threading.Thread.Sleep(1000);

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < 10; i++)
            {
                // Make the 2nd and 8th employee have the first name Joe.
                Employee emp = i == 2 || i == 7 ? new Employee("Joe") : new Employee();
                employees.Add(emp);

                Console.WriteLine(" {0,-25} was hired!   ID: {1,3}", emp.FullName, emp.ID);
                System.Threading.Thread.Sleep(200);
            }

            Console.WriteLine("");
            System.Threading.Thread.Sleep(1000);

            Console.Write("We've got a lot of joes! ");

            List<Employee> joes = new List<Employee>();
            foreach (Employee emp in employees)
            {
                if (emp.FirstName.Equals("Joe"))
                {
                    joes.Add(emp);
                }
            }

            
            Console.WriteLine("{0}, in fact!", joes.Count);
            System.Threading.Thread.Sleep(800);

            // Printing Joes names to the screen.
            Console.Write("Their full names are ");
            ListEmployees(joes);
            Console.WriteLine();

            System.Threading.Thread.Sleep(1500);

            // Using Lambda Expressions
            Console.WriteLine("Now I'll use the Lambda functions to do the same thing... ");
            List<Employee> LambdaJoes = employees.Where(emp => emp.FirstName.Equals("Joe")).ToList();
            Console.WriteLine("Done!");

            Console.Write("Here are the 'Joes' again: ");
            System.Threading.Thread.Sleep(1000);
            ListEmployees(LambdaJoes);
            Console.WriteLine();

            System.Threading.Thread.Sleep(1500);

            // Get all employees with ID > 5
            Console.WriteLine("These are all of the employees with IDs > 5");
            Console.Write(" ");
            ListEmployees(employees.Where(emp => emp.ID > 5).ToList());

            System.Threading.Thread.Sleep(1500);

            Console.WriteLine("\nSee ya later!");
            Console.ReadLine();
        }

        public static void ListEmployees(List<Employee> emps)
        {
            foreach (Employee emp in emps)
            {
                System.Threading.Thread.Sleep(400);
                // If we are on the last joe, Don't put a comma.
                if (emps[emps.Count - 1].FullName.Equals(emp.FullName))
                {
                    Console.Write("and {0} ", emp.FullName);
                }
                else if (emps[emps.Count - 2].FullName.Equals(emp.FullName))
                {
                    Console.Write("{0} ", emp.FullName);
                }
                else
                {
                    Console.Write("{0}, ", emp.FullName);
                }
            }
            Console.WriteLine();
        }
    }
}
