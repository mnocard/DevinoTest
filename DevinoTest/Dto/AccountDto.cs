public class AccountRootobject
{
    public AccountResult result { get; set; }
}

public class AccountResult
{
    public AccountDto account { get; set; }
    public object[] validPacketChannels { get; set; }
}

public class AccountDto
{
    public int companyId { get; set; }
    public string accountType { get; set; }
    public decimal balance { get; set; }
    public decimal credit { get; set; }
    public decimal reserveSms { get; set; }
    public decimal reserveViber { get; set; }
    public decimal reserve { get; set; }
    public int currencyId { get; set; }
    public bool isBlocked { get; set; }
    public decimal notifyThreshold { get; set; }
}
