using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using DevinoTest.Dto;
using DevinoTest.Services;

using Newtonsoft.Json;

namespace DevinoTest
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private const string _AccountApi = "/billing-api/companies/current/account";
        private const string _SendSmsApi = "/sms/messages";
        private const string _SmsStatusApi = "/sms-stat/statuses/get-by-ids";

        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://api.devino.online");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Key 04ee2b47-3a97-4134-98d7-dd21a5223ea6");

            var account = await GetAccountInfoAsync();
            Console.WriteLine($"Ваш баланс составляет: {account.balance} руб.");


            Console.WriteLine("Devino test");
            Console.ReadKey();
        }

        private static async Task<AccountDto> GetAccountInfoAsync()
        {
            AccountRootobject account = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(_AccountApi);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    account = JsonConvert.DeserializeObject<AccountRootobject>(jsonString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return account.result.account;
        }
    }
}
