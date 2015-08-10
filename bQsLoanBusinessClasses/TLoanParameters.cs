using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public class TLoanParameters
    {

        private decimal vInterestRate = 0;
        private int vMinTime = 1;
        private int vMaxTime = 40;
        private decimal vMinAmount = 1000;
        private decimal vMaxAmount = 1000000;
        private int vNrOfPaymentsPerYear = 12;

        public int MinTime
        {
            get { return vMinTime; }

            set { vMinTime = value; }
        }
        public int MaxTime
        {
            get { return vMaxTime; }

            set { vMaxTime = value; }
        }
        public decimal MinAmount
        {
            get { return vMinAmount; }

            set { vMinAmount = value; }
        }
        public decimal MaxAmount
        {
            get { return vMaxAmount; }

            set { vMaxAmount= value; }
        }
        public decimal InterestRate
        {
            get { return vInterestRate; }

            set { vInterestRate = value; }
        }
        public int NrOfPaymentsPerYear
        {
            get { return vNrOfPaymentsPerYear; }

            set { vNrOfPaymentsPerYear = value; }
        }
    }
}
