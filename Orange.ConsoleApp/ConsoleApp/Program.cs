using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Facebook;
using Orange.Data;
using Orange.Model;

 

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are you ready to begin?");
            Console.ReadLine();

            string userName = "joeshepherdmba@outlook.com";

            string password = "Melissa1!";

            //var accessToken = "CAAHY3g6IAiEBAEIpDn5yuC2Swb1a7n8CD1GYZAO8Q4UZBGWmPGc0fMTQZC6Wq95v6C0fIZBkNaxFOSCXN4eCf3RYZCfgOI9NpLuAQBmKCpP2qJGZAGiiFUDKNdbwqi3v18ZARsxn7nqhkZCVWN4w39CAd78SvfnuXQytnlGmZAy8xpTcu4MBrLFsZBlmjntXAs3VsbQ3ZA81wuPTAZDZD";
            //var client = new FacebookClient(accessToken);
            //dynamic me = client.Get("me");
            //string firstName = me.First_Name;
            //Console.WriteLine(me);

            //var registerResult = Register(userName, password);
            //Console.WriteLine("Registration Status Code: {0}", registerResult);


            string token = GetToken(userName, password);


            Console.WriteLine("");

            //Console.WriteLine("Access Token:");

            //Console.WriteLine(token);

            Console.Read();

        }



        static async void GetUser(string id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44300/api/user/f8896b98-b2ea-47c8-98aa-16ded64f72b9");
                if (response.IsSuccessStatusCode)
                {
                    User user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                    Console.WriteLine("UserName: {0}", user.FirstName);
                }
                else
                {
                    Console.WriteLine("Error: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static string Register(string email, string password)

        {

            var registerModel = new

            {

                Email = email,

                Password = password,

                ConfirmPassword = password

            };

            using (var client = new HttpClient())

            {
                string jsonContent = JsonConvert.SerializeObject(registerModel);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                
                
                var response =

                    client.PostAsync(

                    "https://localhost:44300/api/Account/Register",

                    content).Result;

                return response.StatusCode.ToString();

            }

        }





        static string GetToken(string userName, string password)

        {

            var pairs = new List<KeyValuePair<string, string>>

                        {

                            new KeyValuePair<string, string>( "grant_type", "password" ),

                            new KeyValuePair<string, string>( "username", userName ),

                            new KeyValuePair<string, string> ( "Password", password )

                        };

            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())

            {

                var response =

                    client.PostAsync("https://localhost:44300/Token", content).Result;
                    //client.PostAsync("https://localhost:44300/Account/ExternalLogins", content).Result;

                return response.Content.ReadAsStringAsync().Result;

            }

        }


    }

}
