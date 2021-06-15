
namespace DevinoTest.Dto
{
    public class AccountDto
    {
        public int CompanyId { get; set; }

        public string AccountType { get; set; }

        public decimal Balance { get; set; }

        public decimal Credit { get; set; }

        public decimal ReserveSms { get; set; }

        public decimal ReserveViber { get; set; }

        public decimal Reserve { get; set; }

        public int CurrencyId { get; set; }

        public bool IsBlocked { get; set; }

        public decimal DisableThreshold { get; set; }

        public decimal NotifyThreshold { get; set; }
    }
}
