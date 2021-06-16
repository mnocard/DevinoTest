using System.Text.Json.Serialization;

namespace DevinoTest.Dto
{
    /// <summary>Класс обертка для получаемого с сервера ответа</summary>
    public class AccountRootobject
    {
        [JsonPropertyName("result")]
        public AccountResult Result { get; set; }
    }

    /// <summary>Класс обертка для класса аккаунта. Необходим в связи со спецификой ответа сервера</summary>
    public class AccountResult
    {
        [JsonPropertyName("account")]
        public AccountDto Account { get; set; }

        [JsonPropertyName("validPacketChannels")]
        public object[] ValidPacketChannels { get; set; }
    }

    /// <summary>Собственно класс представления данных об аккаунте</summary>
    public class AccountDto
    {
        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        [JsonPropertyName("credit")]
        public decimal Credit { get; set; }

        [JsonPropertyName("reserveSms")]
        public decimal ReserveSms { get; set; }

        [JsonPropertyName("reserveViber")]
        public decimal ReserveViber { get; set; }

        [JsonPropertyName("reserve")]
        public decimal Reserve { get; set; }

        [JsonPropertyName("currencyId")]
        public int CurrencyId { get; set; }

        [JsonPropertyName("isBlocked")]
        public bool IsBlocked { get; set; }

        [JsonPropertyName("notifyThreshold")]
        public decimal NotifyThreshold { get; set; }
    }
}