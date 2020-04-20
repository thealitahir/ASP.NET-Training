using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Parallel.Invoke(
                () => PrintStudentDetails(),
                () => PrintEmployeeDetails()
            );
            Console.ReadLine();*/
            Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

            const int FieldWidthRightAligned = 20;
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");
        }

        private static void PrintEmployeeDetails()
        {
            Singleton fromEmployee = Singleton.GetInstance;
            fromEmployee.PrintDetails("From Employee");
        }

        private static void PrintStudentDetails()
        {
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student");
        }
    }
}
