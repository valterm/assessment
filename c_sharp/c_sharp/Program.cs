using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp
{


    class Trip
    {

        public int studentNo;
        public decimal moneyToMove = 0.00m;
        public List<decimal> payments = new List<decimal>();

        public Trip(int num)
        {
            studentNo = num;
            studentPaid();
            calc(studentNo, payments);            

        }


        public void studentPaid()
        {
            for (int i = 0; i < studentNo; i++)
            {
                bool a = true;
                while (a == true)
                {
                    try
                    {
                        //Parse the amount each student paid
                        //Console.WriteLine("Amount student {0} paid, with 2 decimal accuracy: ", i + 1);
                        decimal temp = decimal.Parse(Console.ReadLine());

                        //Prevent amounts >10000
                        if (temp <= 10000)
                        {
                            payments.Add(temp);
                            a = false;
                        }

                        else
                        {
                            Console.WriteLine("Must be below $10,000.00!");
                        }
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Not a valid number!");
                    }
                }
            }
        }

        public void calc(int no, List<decimal> toSort)
        {
            decimal sum = 0.00m;
            decimal avg = 0.00m;

            //Sum of all payments
            foreach (decimal d in toSort)
            {
                sum += d;
            }

            avg = sum / no;

            //Calculate how much those who paid less owe those who paid more
            foreach (decimal d in toSort)
            {
                if (d < avg)
                {                   
                    moneyToMove += avg - d;
                }
            }

        }
    }
    class Program
    {

        static void Main(string[] args)
        {

            //List to store trips
            List<Trip> trips = new List<Trip>();
            int i = 1;

            //Parse the number of students
            bool b = true;
            while (b == true)
            {
                
                try
                {
                    //Get number of students, disallowing >1000 people
                    //Console.WriteLine("Number of students for trip {0}:", i);
                    int num = int.Parse(Console.ReadLine());
                    if (num > 1000)
                    {
                        Console.WriteLine("Must be 1000 or fewer students!");
                        b = true;
                    }

                    else if (num == 0)
                    {
                        b = false;
                    }

                    else
                    {
                        i++;
                        trips.Add(new Trip(num));
                        b = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a valid number!");
                }
            }

            //Output the minimum amount that needs to be moved to console
            Console.Clear();
            foreach (Trip x in trips)
            {
                Console.WriteLine("${0}", x.moneyToMove.ToString("0.00"));
            }
            Console.ReadKey();


        }
    }
}

