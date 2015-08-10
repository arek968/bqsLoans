using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bQsLoanBusinessClasses;


namespace bQsLoanModule.Controllers
{
    public class LoanDecreasingController : ApiController
    {


        // GET api/GetDecreasingInstallments
        public IEnumerable<TInstallment> Get(string LoanType, int PaybackTime, decimal Amount)
        {
            switch (LoanType)
            {
                case "Housing":
                    LoanBase lb = new LoanHousing(PaybackTime, Amount);
                    TInstallment[] inst = lb.CalculatePaybackPlan(new PaybackDecreasingInstallments());
                    return inst;
                case "Car":
                    LoanBase lc = new LoanCar(PaybackTime, Amount);
                    return lc.CalculatePaybackPlan(new PaybackDecreasingInstallments());
                case "Spending":
                    LoanBase ls = new LoanSpending(PaybackTime, Amount);
                    return ls.CalculatePaybackPlan(new PaybackDecreasingInstallments());
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
