using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bQsLoanBusinessClasses
{
    public abstract class LoanBase
    {
        private int vPaybackTime=0;
        private decimal vAmount=0;
        protected TLoanParameters vLoanParameters;
        
        protected LoanBase(int PaybackTime, decimal Amount)
        {
            vPaybackTime = PaybackTime;
            vAmount = Amount;
        }

        public TInstallment[] CalculatePaybackPlan(IPaybackPlan paybackPlan)
        {
            if (ValidateParameters()) return paybackPlan.CalculatePaybackPlan(vLoanParameters, vAmount, vPaybackTime);
            else return null;
        }

        private bool ValidateParameters()
        {
            if ((vPaybackTime > vLoanParameters.MaxTime) || (vPaybackTime < vLoanParameters.MinTime)) return false;
            if ((vAmount > vLoanParameters.MaxAmount) || (vAmount < vLoanParameters.MinAmount)) return false;
            return true;
        }

        //public TInstallment CalculateTotalPaybackSum(ICalculatePayback paybackPlan)
        //{
        //    TInstallment result = new TInstallment();
        //    TInstallment[] installments = this.CalculatePaybackPlan(paybackPlan);
        //    foreach (TInstallment inst in installments)
        //    {
        //        result.Capital += inst.Capital;
        //        result.Interest += inst.Interest;
        //    }
        //    return result;
        //}
    }
}