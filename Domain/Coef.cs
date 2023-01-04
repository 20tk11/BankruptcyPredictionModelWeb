using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Coef
    {
        public Guid Id { get; set; }
        public int FinancialYear { get; set; }
        public int Audit { get; set; }
        public int? FinancialYearsTillBankruptcy { get; set; }
        public int SingleShareholder { get; set; }
        public int NumberOfEntries { get; set; }
        public int FinancialReportLate { get; set; }
        public int FinancialReportEstablishmentYear { get; set; }
        public double? NOR_1B_1 { get; set; }
        public double? NOR_1B_2 { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}