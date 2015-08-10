using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bQsLoanBusinessClasses;

namespace bQsLoanModule
{
    
    public class LoanEqualController : ApiController
    {

   

        // GET api/GetFixedInstallments
        public IEnumerable<TInstallment> Get(string LoanType, int PaybackTime, decimal Amount)
        {
            switch (LoanType)
            {
                case "Housing":
                    LoanBase lb = new LoanHousing(PaybackTime, Amount);
                    return lb.CalculatePaybackPlan(new MonthlyPaybackEqualInstallments());
                case "Car":
                    LoanBase lc = new LoanCar(PaybackTime, Amount);
                    return lc.CalculatePaybackPlan(new MonthlyPaybackEqualInstallments());
                case "Spending":
                    LoanBase ls = new LoanSpending(PaybackTime, Amount);
                    return ls.CalculatePaybackPlan(new MonthlyPaybackEqualInstallments());
                default: return new TInstallment[0];
            }
        }

        //GET api/GetFixedInstallments
        public IEnumerable<TInstallment> Get()
        {
            return new TInstallment[0];
        }

    }

}
