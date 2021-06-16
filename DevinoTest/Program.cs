using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using DevinoTest.Dto;
using DevinoTest.Services;

namespace DevinoTest
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private const string _AccountApi = "/billing-api/companies/current/account";
        private const string _SendSmsApi = "/sms/messages";
        private const string _AppJson = "application/json";
        private const string _ApiKey = "Key 04ee2b47-3a97-4134-98d7-dd21a5223ea6";

        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://api.devino.online");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_AppJson));
            client.DefaultRequestHeaders.Add("Authorization", _ApiKey);

            var account = await GetAccountInfoAsync(_AccountApi);
            Console.WriteLine($"Ваш баланс составляет: {account.Balance} руб.");

            SmsRootobject result = null;
            if (account.Balance >= 100)
            {
                result = await SendSmsAsync(_SendSmsApi);

                Console.WriteLine("Результаты отправки сообщений:");
                foreach (var message in result.Result)
                    Console.WriteLine($"Статус отправки сообщения с индентификатором {message.MessageId} - {message.Code}");
            }
            Console.ReadKey();
        }

        /// <summary>Получение информации об аккаунте</summary>
        private static async Task<AccountDto> GetAccountInfoAsync(string path)
        {
            AccountRootobject account = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    account = JsonSerializer.Deserialize<AccountRootobject>(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return account.Result.Account;
        }

        /// <summary>Отправка смс</summary>
        private static async Task<SmsRootobject> SendSmsAsync(string path)
        {
            SmsRootobject sms = null;

            try
            {
                var messages = new RootMesagesDto();
                messages.Messages = SmsService.GetSmsList().Select(sms => new MessageDto
                {
                    From = "DTSMS",
                    To = sms.Phone,
                    Text = sms.Message,
                }).ToArray();

                var json = JsonSerializer.Serialize(messages);
                var data = new StringContent(json, Encoding.UTF8, _AppJson);

                HttpResponseMessage response = await client.PostAsync(path, data);
                var result = await response.Content.ReadAsStringAsync();

                sms = JsonSerializer.Deserialize<SmsRootobject>(result);
            }
            catch (Exception)
            {
                throw;
            }

            return sms;
        }
    }
}
