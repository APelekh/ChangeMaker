using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            //calling the function with $4.19.  
            //Notice that when using the decimal format you must end numbers with an 'm'
            ChangeAmount(4.19m);
            ChangeAmount(3.18m);
            ChangeAmount(0.99m);
            ChangeAmount(12.93m);
            ChangeAmount(130.36m);
            ChangeAmount(157.25m);
            ChangeAmount(68.73m);
            

            
            
            Console.ReadKey();
        }


        public static Change ChangeAmountShorter(decimal amount)
        {
            Change amountAsChange = new Change();
            amountAsChange.Quarters = TakeASomething(0.25m, ref amount);
        }
        
        /// <summary>
       /// Calculates and prints out the amounts of quartes, dimes, nickels and pennies that particular amount has
       /// </summary>
       /// <param name="amount">Amount to be processed</param>
       /// <returns>Returns the Change object</returns>
        public static Change ChangeAmount(decimal amount) 
        {
            //this is our object that will hold the data of how many coins of each type to return
            Change amountAsChange = new Change();
           
            //creating counters for each coin type and saving the original amount
            decimal origAmount = amount;
            amountAsChange.Quarters = 0;
            amountAsChange.Dimes = 0;
            amountAsChange.Nickles = 0;
            amountAsChange.Pennies = 0;
            //for Extra credit
            //creating counters for holding amouts of hundreds, fifties, twenties, tens, fives and ones
            int oneDollarCounter = 0;
            int fiveDollarCounter = 0;
            int tenDollarCounter = 0;
            int twentyDollarCounter = 0;
            int fiftyDollarCounter = 0;
            int hunderDollarCounter = 0;
            
            //converting original amount so I can perform calculations on it
            amount = amount * 100;

            //checking for quarters and decreasing the original amount
            while (amount >= 25)
            {
                amountAsChange.Quarters++;
                amount -=25;
            }
            //checking for dimes and decreasing the original amount
            while (amount >= 10)
            {
                amountAsChange.Dimes++;
                amount -= 10;
            }
            //checking for nickels and decreasing the original amount 
            while (amount >= 5)
            {
                amountAsChange.Nickles++;
                amount -= 5;
            }
            //getting pennies amount that left
            amountAsChange.Pennies = decimal.ToInt16(amount);

            //for Extra credit
            //checking for hundreds, fifties, twenties, tens, fives and ones
            while (amount >= 10000)
            {
                hunderDollarCounter++;
                amount -= 10000;
            }
            while (amount >= 5000)
            {
                fiftyDollarCounter++;
                amount -= 5000;
            }
            while (amount >= 2000)
            {
                twentyDollarCounter++;
                amount -= 2000;
            }
            while (amount >= 1000)
            {
                tenDollarCounter++;
                amount -= 1000;
            }
            while (amount >= 500)
            {
                fiveDollarCounter++;
                amount -= 500;
            }
            while (amount >= 100)
            {
                oneDollarCounter++;
                amount -= 100;
            }

            //printing out the results
            Console.WriteLine("Amount: ${0}", origAmount);
            Console.WriteLine("Hundreds: {0}", hunderDollarCounter);
            Console.WriteLine("Fifties: {0}", fiftyDollarCounter);
            Console.WriteLine("Twenties: {0}", twentyDollarCounter);
            Console.WriteLine("Tens: {0}", tenDollarCounter);
            Console.WriteLine("Fives: {0}", fiveDollarCounter);
            Console.WriteLine("Ones: {0}", oneDollarCounter);
            Console.WriteLine("Quarters: {0}", amountAsChange.Quarters);
            Console.WriteLine("Dimes: {0}", amountAsChange.Dimes);
            Console.WriteLine("Nickels: {0}", amountAsChange.Nickles);
            Console.WriteLine("Pennies: {0}", amountAsChange.Pennies);

            
            //C stand for currency
            Console.WriteLine(@"Amount: {0:C}
Quarters:  {1}
Dimes:     {2}
Nickels:   {3}
Pennies:   {4}", origAmount,amountAsChange.Quarters, amountAsChange.Dimes, amountAsChange.Nickles, amountAsChange.Pennies);


            //return our Change Object
            return amountAsChange;
        }

        static int TakeASomething(decimal amountToTake, ref decimal amount)
        {
            int counter = 0;
            while (amount >= amountToTake)
            {
                amount -= amountToTake;
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// Example using the Change class to store data
        /// </summary>
        public static Change Example(decimal amount)
        {
            //creating a new object of our class Change
            Change amountAsChange = new Change();

            //increasing the number of quarters
            amountAsChange.Quarters++;
            amountAsChange.Quarters += 1;
            amountAsChange.Quarters = amountAsChange.Quarters + 1;


            //outputting to the console
            Console.WriteLine("Quarters: " + amountAsChange.Quarters);

            //returning the object
            return amountAsChange;
        }

    }

    public class Change
    {
        /// <summary>
        /// This is property to hold the number of Quarters to be returned as change
        /// </summary>
        public int Quarters { get; set; }

        /// <summary>
        /// This is property to hold the number of Dimes to be returned as change
        /// </summary>
        public int Dimes { get; set; }

        /// <summary>
        /// This is property to hold the number of Nickles to be returned as change
        /// </summary>
        public int Nickles { get; set; }

        /// <summary>
        /// This is property to hold the number of Pennies to be returned as change
        /// </summary>public int Nickles { get; set; }
        public int Pennies { get; set; }

        /// <summary>
        /// This is a constructor, it initializes a new instance of the class (called an object).  This sets it's default values.
        /// </summary>
        public Change()
        {
            this.Quarters = 0;
            this.Dimes = 0;
            this.Nickles = 0;
            this.Pennies = 0;
        }
    }
}
