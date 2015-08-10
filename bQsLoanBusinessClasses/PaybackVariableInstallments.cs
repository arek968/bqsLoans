using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public class PaybackDecreasingInstallments : IPaybackPlan
    {

        public TInstallment[] CalculatePaybackPlan(TLoanParameters LoanParameters, decimal Amount, int PaybackYears)
        {
            List<TInstallment> installments = new List<TInstallment>();
            int PaybackPeriods = PaybackYears * LoanParameters.NrOfPaymentsPerYear;
            decimal currInstallment = Amount / PaybackPeriods;
            decimal currAmount = Amount;
            for (int i = 1; i <= PaybackPeriods; i++)
            {
                TInstallment installment = new TInstallment();
                installment.Month = i;
                installment.Capital = currInstallment;
                installment.Interest = (currAmount * LoanParameters.InterestRate / 100 / LoanParameters.NrOfPaymentsPerYear);
                installments.Add(installment);
                currAmount -= currInstallment;
            }
            return installments.ToArray();
        }
    }
}
