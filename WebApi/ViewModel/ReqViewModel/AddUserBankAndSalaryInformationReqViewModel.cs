namespace WebApi.ViewModel.ReqViewModel
{
    public class AddUserBankAndSalaryInformationReqViewModel
    {
        public int EmployeeId { get; set; }
        public string? BankName { get; set; }

        public string? NameOnTheAccount { get; set; }

        public string? AccountNo { get; set; }

        public string? BankBranch { get; set; }

        public string? BankIfsc { get; set; }

        public string? PfaccountNo { get; set; }

        public string? AadharNo { get; set; }

        public string? Panno { get; set; }

        public decimal? MonthlySalary { get; set; }

        public decimal? Pfamount { get; set; }

        public decimal? Esiamount { get; set; }

        public decimal? Ptamount { get; set; }

        public bool? PfApplicable { get; set; }

        public bool? PtApplicable { get; set; }

        public bool? EsiApplicable { get; set; }
    }
}
