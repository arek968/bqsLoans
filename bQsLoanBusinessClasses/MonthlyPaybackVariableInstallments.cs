using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public class MonthlyPaybackDecreasingInstallments : IPaybackPlan
    {

        public TInstallment[] CalculatePaybackPlan(TLoanParameters LoanParameters, decimal Amount, int PaybackTime)
        {
            List<TInstallment> installments = new List<TInstallment>();
            decimal currInstallment = Amount / PaybackTime;
            decimal currAmount = Amount;
            for (int i = 1; i <= PaybackTime; i++)
            {
                TInstallment installment = new TInstallment();
                installment.Month = i;
                installment.Capital = currInstallment;
                installment.Interest = (currAmount * LoanParameters.InterestRate / 100 / 12);
                installments.Add(installment);
                currAmount -= currInstallment;
            }
            return installments.ToArray();
        }
    }
}
