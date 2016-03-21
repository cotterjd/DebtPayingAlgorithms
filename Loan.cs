using System;

namespace DebtPayOff
{
	public class Loan
	{
		public double principle;
		public double interestRate; 
		public double minPayment;
		
		public Loan(double princ, double rate, double minPay)
		{
			principle = princ;
			interestRate = rate/100;
			minPayment = minPay;
		}
		
		public override string ToString ()
		{
			 return "principle: " + principle +"\ninterest rate: " +interestRate;
		}
	}
}

