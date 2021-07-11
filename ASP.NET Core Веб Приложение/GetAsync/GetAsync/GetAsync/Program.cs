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
            for (int i = 4; i < 14; i++)
            {
                await GetAndWrite(i);
            }
           
        }
        static readonly HttpClient client = new HttpClient();
        static async Task GetAndWrite(int id)
        {
            String strText; 
            try
                {
                    string url = string.Format("https://jsonplaceholder.typicode.com/posts/{0}", id);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Post post = JsonSerializer.Deserialize<Post>(responseBody);
                    strText = Convert.ToString(post.userId) + "\n\n" + Convert.ToString(post.id) + "\n\n" + Convert.ToString(post.title) + "\n\n" + Convert.ToString(post.body) + "\n\n";
                    await using (StreamWriter sw = new StreamWriter(filename, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(strText);
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            
        }
    }
}
