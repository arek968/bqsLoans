using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public class LoanHousing : LoanBase
    {
        public LoanHousing(int PaybackTime, decimal Amount) : base(PaybackTime, Amount)
        {
            vLoanParameters = new TLoanParameters();
            vLoanParameters.InterestRate = (decimal)(3.5);
        }

    }
}