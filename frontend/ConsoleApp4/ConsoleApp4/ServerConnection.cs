using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class ServerConnection
    {
        HttpClient client = new HttpClient();
        public ServerConnection(string url)
        {
            client.BaseAddress = new Uri(url);
        }
        public async Task<List<Airplanes>> GetPlanes()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("/planes");
                response.EnsureSuccessStatusCode();
                string responseString = await response.Content.ReadAsStringAsync();
                List<Airplanes> result = JsonSerializer.Deserialize<List<Airplanes>>(responseString);
                return result;
            }catch(Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
        public async Task<bool> Login(string username, string password)
        {
            try
            {
                Users oneUser = new Users(username, password);
                string jsonString = JsonSerializer.Serialize(oneUser);
                StringContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Apllication/JSON");
                HttpResponseMessage response = await client.PostAsync("/user/login", sendThis);
                response.EnsureSuccessStatusCode();
                string responseString = await response.Content.ReadAsStringAsync();
                Token result = JsonSerializer.Deserialize<Token>(responseString);
                client.DefaultRequestHeaders.Add("authorization", result.token);
                Console.WriteLine(result.message);
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }
        public void Logout()
        {
            client.DefaultRequestHeaders.Clear();
        }

        public async Task<List<Airplanes>> getMyPlanes()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("/planes/my");
                response.EnsureSuccessStatusCode();
                string responseString = await response.Content.ReadAsStringAsync();
                List<Airplanes> result = JsonSerializer.Deserialize<List<Airplanes>>(responseString);
                return result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<bool> createPlane(string name, string type, int capacity, int range)
        {
            try
            {
                Airplanes onePlane = new Airplanes(name, type, capacity, range);
                string jsonString = JsonSerializer.Serialize(onePlane);
                StringContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Apllication/JSON");
                HttpResponseMessage response = await client.PostAsync("/planes", sendThis);
                response.EnsureSuccessStatusCode();
                string responseString = await response.Content.ReadAsStringAsync();
                ServerResponse result = JsonSerializer.Deserialize<ServerResponse>(responseString);
                Console.WriteLine(result.message);

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }
    }
}
