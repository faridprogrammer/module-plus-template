using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Accounting.Dto
{
    public class BalanceDto
    {
        public decimal TotalCredit
        {
            get;
            set;
        }

        public decimal TotalDebit
        {
            get;
            set;
        }

        public decimal Balance => TotalCredit - TotalDebit;
    }
}
