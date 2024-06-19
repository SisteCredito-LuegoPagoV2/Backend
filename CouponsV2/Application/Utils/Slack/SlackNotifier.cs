using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SlackNotifier
{
    private readonly string _webhookUrl;

    public SlackNotifier(string webhookUrl)
    {
        _webhookUrl = webhookUrl;
    }

    public async Task SendMessageAsync(string message)
    {
        using (var client = new HttpClient())
        {
            var payload = new
            {
                text = message
            };
            var payloadJson = JsonConvert.SerializeObject(payload);
            var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_webhookUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
