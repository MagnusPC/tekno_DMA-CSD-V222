using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace botapp2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        private async Task SendTelegramAsync(string theMessage)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.telegram.org/botyourBotApiKey/sendMessage");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("chat_id", "yourChatId"));
            collection.Add(new("text", theMessage));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        public void OnPost(string action="err", string myText="err") 
        { 
            if (action== "sendtelegram")
            {
                SendTelegramAsync(myText);
            }
        }
    }
}