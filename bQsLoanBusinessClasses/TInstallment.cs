using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public class TInstallment
    {
        private int vMonth = 0;
        private decimal vCapital = 0;
        private decimal vInterest = 0;
        public int Month
        {
            get { return vMonth; }

            set { vMonth = value; }
        }
        public decimal Capital
        {
            get { return vCapital; }

        set { vCapital = Math.Round(value,2); }
        }
        public decimal Interest
        {
            get { return vInterest; }

            set { vInterest = Math.Round(value,2); }
        }
        public decimal Payment
        {
            get { return Math.Round( vCapital + vInterest, 2); }
        }
    }
}
