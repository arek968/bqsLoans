using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public interface IPaybackPlan
    {
        TInstallment[] CalculatePaybackPlan(TLoanParameters LoanParameters, decimal Amount, int PaybackTime);
    }
}
