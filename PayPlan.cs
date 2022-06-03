using System;
using System.Collections;

namespace DebtPayOff
{
  public class PayPlan
  {
    public Loan[] loans;
    private int months;
    private double interestPaid;
    private double payment;

    public PayPlan(Loan[] loans, double extraMoneyForDebt)
    {
        Loan[] tempLoans = new Loan[loans.Length];
        for (int i = 0; i < loans.Length; i++)
        {
            tempLoans[i] = new Loan(loans[i].principle, loans[i].interestRate * 100, loans[i].minPayment);
        }
        this.loans = tempLoans;
        payment = extraMoneyForDebt;
        months = 0;
        interestPaid = 0.0;
    }
    
    public double payLoans(Loan[] loans)
    {
      
      if(loans.Length == 0)
      {
        return interestPaid;  
      }
      else
      {
        loans = payLoanOff (loans);
      }
      return payLoans(loans);
    }
    
    private Loan[] payLoanOff(Loan[] loans)
    {
      while(loans[0].principle > this.payment)
      {
        months ++;
        interestPaid += pay(loans[0], this.payment);
        for(var i=1; i<loans.Length; i++)
        {
          interestPaid += pay (loans[i], loans[i].minPayment);  
        }
      }
      months++;
      var payment = loans[0].principle;
      loans[0].principle = loans[0].principle - payment;
      
      this.payment += loans[0].minPayment;
      
      Loan[] newLoans = new Loan[loans.Length-1];
      for(var i=0; i<newLoans.Length; i++)
      {
        newLoans[i] = loans[i+1];
      }
      
      return newLoans;
    }
    
    private double pay(Loan loan, double payment)
    {
      var rate = loan.interestRate;
      var interest = loan.principle * rate;
      var monthlyInterest = interest / 12;
      loan.principle = loan.principle - (payment - monthlyInterest);
      
      return monthlyInterest;
    }
    
    public void Info()
    { 
      payLoans (this.loans);
      Console.WriteLine ("Total Time: " + months/12 + " years and " + months%12 + " months" ); 
      Console.WriteLine ("Total Interest Paid: $" + Math.Round(interestPaid, 2));
    }
  }
}
