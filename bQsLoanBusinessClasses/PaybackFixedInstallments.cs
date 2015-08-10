using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public class PaybackEqualInstallments: IPaybackPlan
    {

        public TInstallment[] CalculatePaybackPlan(TLoanParameters LoanParameters, decimal Amount, int PaybackYears)
        {
            List<TInstallment> installments = new List<TInstallment>();
            int PaybackPeriods = PaybackYears * LoanParameters.NrOfPaymentsPerYear;
            double y = 1 + (double)LoanParameters.InterestRate/ 100 / LoanParameters.NrOfPaymentsPerYear;
            decimal dInstallment = (decimal)( (double)Amount * Math.Pow( y , PaybackPeriods) * (y - 1) / ( Math.Pow(y, PaybackPeriods) - 1));

            decimal currAmount = Amount;

            for (int i = 1; i <= PaybackPeriods; i++)
            {
                TInstallment installment = new TInstallment();
                installment.Month = i;
                installment.Interest = (currAmount * LoanParameters.InterestRate/ 100 / LoanParameters.NrOfPaymentsPerYear);
                installment.Capital = dInstallment - installment.Interest; 
                installments.Add(installment);

                currAmount -= installment.Capital;
            }
            return installments.ToArray();
        }

    }

}
