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

        static async Task Main(string[] args)
        {


            await ProcessRepositories();
            Console.WriteLine("Devino test");
            Console.ReadKey();
        }

        private static async Task ProcessRepositories()
        {
            //string key = 
            //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            //return Convert.ToBase64String(plainTextBytes);


            client.BaseAddress = new Uri("https://api.devino.online");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Key 04ee2b47-3a97-4134-98d7-dd21a5223ea6");



            try
            {
                var account = await GetBalanceAsync("/billing-api/companies/current/account");
                Console.WriteLine(account.Balance);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static async Task<AccountDto> GetBalanceAsync(string path)
        {
            AccountDto account = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                account = JsonConvert.DeserializeObject<AccountDto>(jsonString);
            }
            return account;
        }
    }
}
