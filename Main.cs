using System;
using System.Collections;
using System.Text;

namespace DebtPayOff
{
	class MainClass
	{
		
		private static Loan loan001 = new Loan(667, 3.4);
		private static Loan loan002 = new Loan(1878, 3.4);
		private static Loan loan003 = new Loan(2750, 3.4);
		//private static Loan loan004 = new Loan(3030, 6.8); PAID!
		private static Loan loan005 = new Loan(3301, 6);
		private static Loan loan006 = new Loan(3399, 5.6);
		//private static Loan loan007 = new Loan(3500, 6.8); PAID!
		private static Loan loan008 = new Loan(4500, 6);
		private static Loan loan009 = new Loan(5500, 3.4);
		private static Loan carLoan01 = new Loan(carLoanPrinciple(), 5.37, 191.48);
		
		
		private static Loan loan01 = new Loan(667, 3.4);
		private static Loan loan02 = new Loan(1878, 3.4);
		private static Loan loan03 = new Loan(2750, 3.4);
		//private static Loan loan04 = new Loan(3030, 6.8); PAID!
		private static Loan loan05 = new Loan(3301, 6);
		private static Loan loan06 = new Loan(3399, 5.6);
		//private static Loan loan07 = new Loan(3500, 6.8); PAID!
		private static Loan loan08 = new Loan(4500, 6);
		private static Loan loan09 = new Loan(5500, 3.4);
		private static Loan carLoan1 = new Loan(carLoanPrinciple(), 5.37, 191.48);
		
			
		private static Loan loan1 = new Loan(667, 3.4);
		private static Loan loan2 = new Loan(1878, 3.4);
		private static Loan loan3 = new Loan(2750, 3.4);
		//private static Loan loan4 = new Loan(3030, 6.8); PAID!
		private static Loan loan5 = new Loan(3301, 6);
		private static Loan loan6 = new Loan(3399, 5.6);
		//private static Loan loan7 = new Loan(3500, 6.8); PAID!
		private static Loan loan8 = new Loan(4500, 6);
		private static Loan loan9 = new Loan(5500, 3.4);
		private static Loan carLoan = new Loan(carLoanPrinciple (), 5.37, 191.48);
		
		
		private static Loan loan0001 = new Loan(667, 3.4);
		private static Loan loan0002 = new Loan(1878, 3.4);
		private static Loan loan0003 = new Loan(2750, 3.4);
		//private static Loan loan0004 = new Loan(3030, 6.8); PAID!
		private static Loan loan0005 = new Loan(3301, 6);
		private static Loan loan0006 = new Loan(3399, 5.6);
		//private static Loan loan0007 = new Loan(3500, 6.8); PAID!
		private static Loan loan0008 = new Loan(4500, 6);
		private static Loan loan0009 = new Loan(5500, 3.4);
		private static Loan carLoan001 = new Loan(carLoanPrinciple(), 5.37, 191.48);
		
		
		public static void Main (string[] args)
		{			
			var totalDebt = loan1.principle + loan2.principle + loan3.principle + loan5.principle + loan6.principle + loan8.principle + 
				loan9.principle + carLoan.principle;
			Console.WriteLine ("Total Debt: $" + Math.Round(totalDebt, 2) + "\n");
	
			//smallest loans
			Loan[] loansS = {loan001, loan002, loan003, loan005, loan006, loan008, loan009, carLoan01};
			Console.WriteLine ("Paying off smallest loans first:");
			PayPlan smallestLoansFirst = new PayPlan(loansS);
			smallestLoansFirst.Info ();
			
			Console.WriteLine ();		
			
			 // largest loans			  
			Loan[] loansL = {carLoan1, loan09, loan08, loan06, loan05, loan03, loan02, loan01};
			Console.WriteLine("Paying off largest loans first:");
			PayPlan LargestLoansFirst = new PayPlan(loansL);
			LargestLoansFirst.Info();
			
			Console.WriteLine ();
			
			//highest interest/largest loans
			Loan[] loansHL = {loan8, loan5, loan6, carLoan, loan9, loan3, loan2, loan1};
			Console.WriteLine("Paying off highest interest rate/largest loans first:");
			PayPlan highestInterestLargest = new PayPlan(loansHL);
			highestInterestLargest.Info();
				
			Console.WriteLine ();
			
			// highest interest/smallest loan
			Loan[] loansPOF = {loan0005, loan0008, loan0006, carLoan001, loan0001, loan0002, loan0003, loan0009};
			Console.WriteLine("Paying off highest interest rate/smallest loans first:");
			PayPlan highestInterestSmallest = new PayPlan(loansPOF);
			highestInterestSmallest.Info();	
		}
		
		public static double carLoanPrinciple()
		{
			double loan = 12150;
			var rate = 5.37;
			var interest = loan * (rate/100);
			double mInterest = interest/12;
			var payment = 191.48;
			
			var counter = 0;
			while (counter < 11)
			{
				loan = loan - (payment - mInterest);
				counter++;
			}
			return loan;
		}
		
	}//end MainClass
	
}
