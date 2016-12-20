using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        struct SalespersonInformation //Struct to store the information which will be called upon at the end of the program, after entering all salespersons.
        {
            public String Name;
            public String IdNumber;
            public double Wages; 
            public double Commission;
            public double GrossPay;
        };
        static void Main(string[] args)
        {
            //Scott Robinson
            //Task 2
            //CSCI100-Introduction to Programming
            //12-03-2015

            Console.Write("Please enter the number of salespersons you wish to process: ");
            int numberToProcess = Convert.ToInt16(Console.ReadLine());
            SalespersonInformation[] salesPersonArray = new SalespersonInformation[numberToProcess]; //Allows a struct array to be created based on the user input. 

            Console.WriteLine();
            Console.WriteLine();

            int count; //Allows for a perfect match of how many salespersons to save vs the number expected to be input.
            double totalCommission = 0; //Starting point for the total of all commission.
            double totalWages = 0; //Starting point for the total of all wages. 
            double totalGrossPay = 0; //Starting point for the total of all wages + commission. 

            for (count = 0; count < salesPersonArray.Length; count++) //Starts the process of gathering salesperson information. 
            {
                Console.Write("Please enter the salespersons name: ");
                salesPersonArray[count].Name = Console.ReadLine(); //Assigns a Name to the current "count" which is then applied to the index of the array that correlates to the count. 

                Console.Write("Please enter the salespersons ID number: ");
                salesPersonArray[count].IdNumber = Console.ReadLine(); //Assigns an ID Number based on the count, which is applied to the index of the array that correlates to the count. 

                Console.Write("Please enter the salespersons class: ");
                string salesClass = Convert.ToString(Console.ReadLine()); //Identifies the class, which does not need to be saved. 

                if (salesClass != "1" && salesClass != "2" && salesClass != "3" && salesClass != "4") //This immediately lets the user know if no calculations will be done. 
                {
                    Console.WriteLine("You have entered an invalid class!! No commission or wages will be calculated for this salesperson!!!");
                }

                Console.Write("Please enter the amount of hours worked: ");
                int hoursWorked = Convert.ToInt32(Console.ReadLine()); //Hours worked for each salesperson is entered but not saved. 

                Console.Write("Please enter the salespersons sales amount: ");
                double salesAmount = Convert.ToDouble(Console.ReadLine()); //Sales amount for each salesperson is entered but not saved. 

                Console.WriteLine();

                if (salesClass == "1") //Identifying which class was entered. Based on the class, selects the appropriate Method to use. Also assigns Wages, Commission and Gross pay to the struct/index of the array based on the current "count".
                {
                    salesPersonArray[count].Commission = Class1(salesAmount);
                    salesPersonArray[count].Wages = Class1(hoursWorked);
                    salesPersonArray[count].GrossPay = salesPersonArray[count].Commission + salesPersonArray[count].Wages;
                }
                else if (salesClass == "2") //Identifying which class was entered. Based on the class, selects the appropriate Method to use. Also assigns Wages, Commission and Gross pay to the struct/index of the array based on the current "count".
                {
                    salesPersonArray[count].Commission = Class2(salesAmount);
                    salesPersonArray[count].Wages = Class2(hoursWorked);
                    salesPersonArray[count].GrossPay = salesPersonArray[count].Commission + salesPersonArray[count].Wages;
                }
                else if (salesClass == "3") //Identifying which class was entered. Based on the class, selects the appropriate Method to use. Also assigns Wages, Commission and Gross pay to the struct/index of the array based on the current "count".
                {
                    salesPersonArray[count].Commission = Class3(salesAmount);
                    salesPersonArray[count].Wages = Class3(hoursWorked);
                    salesPersonArray[count].GrossPay = salesPersonArray[count].Commission + salesPersonArray[count].Wages;
                }
                else if (salesClass == "4") //Identifying which class was entered. Based on the class, selects the appropriate Method to use. Also assigns Wages, Commission and Gross pay to the struct/index of the array based on the current "count".
                {
                    salesPersonArray[count].Commission = Class4(salesAmount);
                    salesPersonArray[count].Wages = Class4(hoursWorked);
                    salesPersonArray[count].GrossPay = salesPersonArray[count].Commission + salesPersonArray[count].Wages;
                }

                totalCommission = salesPersonArray[count].Commission + totalCommission; //Continues to add to the total of all commissions from each loop to be displayed once all salespersons have been entered. 
                totalWages = salesPersonArray[count].Wages + totalWages; //Continues to add to the total of all wages from each loop to be displayed once all salespersons have been entered.
                totalGrossPay = salesPersonArray[count].Commission + salesPersonArray[count].Wages + totalGrossPay; //Continues to add to the total gross pay from each loop to be displayed once all salespersons have been entered. 
            }

            Console.Write("The total commission for all salespersons is {0:C}", totalCommission); //Simple output of the total commissions that have been added together from the loop.
            Console.WriteLine();
            Console.Write("The total wages for all salespersons is {0:C}", totalWages); //Simple output of the total wages that have been added together from the loop.
            Console.WriteLine();
            Console.Write("The total gross pay for all salespersons is {0:C}", totalGrossPay); //Simple output of the total gross pay that has been added together from the loop. 
            Console.WriteLine();
            Console.WriteLine();

            foreach (SalespersonInformation salesPersons in salesPersonArray) //Starting to use foreach loops more as it's very handy. Takes each piece of struct information from the array and displays the information called for. 
            {
                Console.Write("Salespersons name: " + salesPersons.Name); //The name tied to each salesperson. 
                Console.WriteLine();
                Console.Write(salesPersons.Name + "'s ID number: {0:C}", salesPersons.IdNumber); //The ID Number tied to each salesperson.
                Console.WriteLine();
                Console.Write(salesPersons.Name + "'s wages: {0:C}", salesPersons.Wages); //The wage which is computated through the method and assigned to each piece of the struct in the array based on the loop count.
                Console.WriteLine();
                Console.Write(salesPersons.Name + "'s commission: {0:C}", salesPersons.Commission); //The commission which is computated through the method and assigned to each piece of the struct in the array based on the loop count.
                Console.WriteLine();
                Console.Write(salesPersons.Name + "'s gross pay: {0:C}", salesPersons.GrossPay); //The gross pay which is computated by simply adding the returned values of each method and assigning them into the array based on the loop count. 
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        /// <summary>
        /// If the class is identified as class 1, this method is used to calculate the commission. 
        /// </summary>
        /// <param name="salesAmount">This is the amount(input by the user) that is used in the calculation of the commission.</param>
        /// <returns>Due to the complexity of the if statements, a variable was needed for the commission for class 1 to be returned. 
        /// Based on the sales amount, a different calculation takes place and is assigned to the individualCommission variable.</returns>
        static double Class1(double salesAmount)
        {
            double individualCommission = 0;

            if (salesAmount <= 2500)
            {
                individualCommission = (salesAmount * .050);
            }
            else if (salesAmount > 2500 && salesAmount < 4500)
            {
                individualCommission = salesAmount * .065;
            }
            else if (salesAmount >= 4500)
            {
                individualCommission = salesAmount * .090;
            }
            return individualCommission;
        }
        /// <summary>
        /// Calculating the wages based on the class and pay rate.
        /// </summary>
        /// <param name="hoursWorked">This is the amount(input by the user) that is used in the calculation of the wages, to include overtime if necessary.</param>
        /// <returns>Returns either regular pay or regular pay with overtime pay. </returns>
        static double Class1(int hoursWorked)
        {
            double initialPay = 14.50 * 40;
            double overtimePay = 0;

            if (hoursWorked > 40)
            {
                overtimePay = (hoursWorked - 40) * (14.50 * 1.5);
                return initialPay + overtimePay;
            }
            else
            {
                return hoursWorked * 14.50;
            }
        }
        /// <summary>
        /// If the class is identified as class 2, this method is used to calculate the commission. 
        /// </summary>
        /// <param name="salesAmount">This is the amount(input by the user) that is used in the calculation of the commission.</param>
        /// <returns>Since anything under 2500 falls into the first half of the if statement, either end of the if statement can be returned since it is either one
        /// side or the other.</returns>
        static double Class2(double salesAmount)
        {
            if (salesAmount <= 2500)
            {
                return (salesAmount * .055);
            }
            else
            {
                return (salesAmount * .065);
            }

        }
        /// <summary>
        /// Calculating the wages based on the class and pay rate.
        /// </summary>
        /// <param name="hoursWorked">This is the amount(input by the user) that is used in the calculation of the wages, to include overtime if necessary.</param>
        /// <returns>Returns either regular pay or regular pay with overtime pay. </returns>
        static double Class2(int hoursWorked)
        {
            double initialPay = 20.25 * 40;
            double overtimePay = 0;

            if (hoursWorked > 40)
            {
                overtimePay = (hoursWorked - 40) * (20.25 * 1.5);
                return initialPay + overtimePay;
            }
            else
            {
                return hoursWorked * 20.25;
            }
        }
        /// <summary>
        /// If the class is identified as class 3, this method is used to calculate the commission. 
        /// </summary>
        /// <param name="salesAmount">This is the amount(input by the user) that is used in the calculation of the commission.</param>
        /// <returns>Since there is only one rate for class 3, the simply equation is returned to the method each time it is used.</returns>
        static double Class3(double salesAmount)
        {
           return (salesAmount * .075);
        }
        /// <summary>
        /// Calculating the wages based on the class and pay rate.
        /// </summary>
        /// <param name="hoursWorked">This is the amount(input by the user) that is used in the calculation of the wages, to include overtime if necessary.</param>
        /// <returns>Returns either regular pay or regular pay with overtime pay. </returns>
        static double Class3(int hoursWorked)
        {
            double initialPay = 16.50 * 40;
            double overtimePay = 0;

            if (hoursWorked > 40)
            {
                overtimePay = (hoursWorked - 40) * (16.50 * 1.5);
                return initialPay + overtimePay;
            }
            else
            {
                return hoursWorked * 16.50;
            }
        }
        /// <summary>
        /// If the class is identified as class 4, this method is used to calculate the commission. 
        /// </summary>
        /// <param name="salesAmount">This is the amount(input by the user) that is used in the calculation of the commission.</param>
        /// <returns>Since there is only one rate for class 4, the simply equation is returned to the method each time it is used.</returns>
        static double Class4(double salesAmount)
        {
            return (salesAmount * .090);
        }
        /// <summary>
        /// Calculating the wages based on the class and pay rate.
        /// </summary>
        /// <param name="hoursWorked">This is the amount(input by the user) that is used in the calculation of the wages, to include overtime if necessary.</param>
        /// <returns>Returns either regular pay or regular pay with overtime pay. </returns>
        static double Class4(int hoursWorked)
        {
            double initialPay = 19.75 * 40;
            double overtimePay = 0;

            if (hoursWorked > 40)
            {
                overtimePay = (hoursWorked - 40) * (19.75 * 1.5);
                return initialPay + overtimePay;
            }
            else
            {
                return hoursWorked * 19.75;
            }
        }
    }
}
