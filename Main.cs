using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DebtPayOff
{
	class MainClass
	{	
		public static void Main (string[] args)
		{
            var inputMoreLoans = true;
            List<Loan> loans = new List<Loan>();
            while (inputMoreLoans)
            {
                Console.Write("Enter loan amount: ");
                var amount = double.Parse(Console.ReadLine());

                Console.Write("Enter interest rate: ");
                var rate = double.Parse(Console.ReadLine());

                Console.Write("Enter minimum payment: ");
                var minPayment = double.Parse(Console.ReadLine());

                loans.Add(new Loan(amount, rate, minPayment));

                Console.WriteLine("Add another loan? (y or n)");
                if (Console.ReadLine() == "n")
                {
                    inputMoreLoans = false;
                }
            }

            Console.WriteLine("How much money do you have each month to put toward debt?");
            double extraMoney = double.Parse(Console.ReadLine());

            var totalDebt = 0.0;

            for (int i = 0; i < loans.Count; i++)
            {
                totalDebt += loans[i].principle;
            }
			Console.WriteLine ("Total Debt: $" + Math.Round(totalDebt, 2) + "\n");
	
			//smallest loans	
            List<Loan> loansS = loans.OrderBy(x => x.principle).ThenByDescending(y => y.interestRate).ToList();
            Console.WriteLine("Paying off smallest loans first:");
            PayPlan smallestLoansFirst = new PayPlan(loansS.ToArray(), extraMoney);
            smallestLoansFirst.Info();
			
			Console.WriteLine ();

            // largest loans			  
            List<Loan> loansL = loans.OrderByDescending(x => x.principle).ThenByDescending(y => y.interestRate).ToList();
            Console.WriteLine("Paying off largest loans first:");
            PayPlan LargestLoansFirst = new PayPlan(loansL.ToArray(), extraMoney);
            LargestLoansFirst.Info();

            Console.WriteLine();

            //highest interest/largest loans
            List<Loan> loansHL = loans.OrderByDescending(x => x.principle).ThenByDescending(y => y.interestRate).ToList();
            Console.WriteLine("Paying off highest interest rate/largest loans first:");
            PayPlan highestInterestLargest = new PayPlan(loansHL.ToArray(), extraMoney);
            highestInterestLargest.Info();

            Console.WriteLine();

            // highest interest/smallest loan
            List<Loan> loansPOF = loans.OrderByDescending(x => x.principle).ThenByDescending(y => y.interestRate).ToList();
            Console.WriteLine("Paying off highest interest rate/smallest loans first:");
            PayPlan highestInterestSmallest = new PayPlan(loansPOF.ToArray(), extraMoney);
            highestInterestSmallest.Info();
		}

        public static double carLoanPrinciple(double principle, double interestRate, double monthlyPayment, int remaingMonths)
        {
            double loan = principle;
            var rate = interestRate;
            var interest = loan * (rate / 100);
            double mInterest = interest / 12;
            var payment = monthlyPayment;

            var counter = 0;
            while (counter < remaingMonths)
            {
                loan = loan - (payment - mInterest);
                counter++;
            }
            return loan;
        }
		
	}//end MainClass
	
}
