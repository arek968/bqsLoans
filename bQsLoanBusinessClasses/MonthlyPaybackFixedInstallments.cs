using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public class MonthlyPaybackEqualInstallments: IPaybackPlan
    {

        public TInstallment[] CalculatePaybackPlan(TLoanParameters LoanParameters, decimal Amount, int PaybackTime)
        {
            List<TInstallment> installments = new List<TInstallment>();
            
            double y = 1 + (double)LoanParameters.InterestRate/ 100 / 12;
            decimal dInstallment = (decimal)( (double)Amount * Math.Pow( y , PaybackTime) * (y - 1) / ( Math.Pow(y, PaybackTime) - 1));

            decimal currAmount = Amount;

            for (int i = 1; i <= PaybackTime; i++)
            {
                TInstallment installment = new TInstallment();
                installment.Month = i;
                installment.Interest = (currAmount * LoanParameters.InterestRate/ 100 / 12);
                installment.Capital = dInstallment - installment.Interest; 
                installments.Add(installment);

                currAmount -= installment.Capital;
            }
            return installments.ToArray();
        }

    }

}
