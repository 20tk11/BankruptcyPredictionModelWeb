// public Guid Id { get; set; }
//         public string JARCODE { get; set; }
//         public string Name { get; set; }
//         public int RegistrationYear { get; set; }
//         public int? DeregistrationYear { get; set; }
//         public int BusinessSector { get; set; }
//         public int IsBankrupt { get; set; }
//         public User User { get; set; }
//         public string UserId { get; set; }
//         public ICollection<CoefDto> CompanyCoefs { get; set; } = new List<CoefDto>();
//         public int? BankruptcyCaseStartYear { get; set; }

export interface Company {
    id: string;
    jarcode: string;
    name: string;
    registrationYear: number;
    deregistrationYear: number;
    businessSector: number;
    isBankrupt: number;
    bankruptcyCaseStartYear: number;
}

export interface Company {
    id: string;
    jarcode: string;
    name: string;
    registrationYear: number;
    deregistrationYear: number;
    businessSector: number;
    isBankrupt: number;
    bankruptcyCaseStartYear: number;
}



