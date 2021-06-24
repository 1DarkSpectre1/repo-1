using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GetAsync
{
    class Program
    {

    
        static string filename = "result.txt";
        static async Task Main(string[] args)
        {

            Console.WriteLine("Привет для начала нажмите Enter!");
            Console.ReadLine();
            File.WriteAllText(filename, "");
            for (int i = 1; i < 11; i++)
            {
                await GetAndWrite(i);
            }
           
        }
        static readonly HttpClient client = new HttpClient();
        static async Task GetAndWrite(int id)
        {
           
                try
                {
                    string url = string.Format("https://jsonplaceholder.typicode.com/posts/{0}", id);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Post post = JsonSerializer.Deserialize<Post>(responseBody);
                    File.AppendAllText(filename,Convert.ToString( post.userId));
                    File.AppendAllText(filename, Environment.NewLine);
                    File.AppendAllText(filename, Convert.ToString(post.id));
                    File.AppendAllText(filename, Environment.NewLine);
                    File.AppendAllText(filename, Convert.ToString(post.title));
                    File.AppendAllText(filename, Environment.NewLine);
                    File.AppendAllText(filename, Convert.ToString(post.body));
                    File.AppendAllText(filename, Environment.NewLine);
                    File.AppendAllText(filename, Environment.NewLine);

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            
        }
    }
}
