using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiChecker
{
    private readonly string _apiUrl;
    private readonly SlackNotifier _slackNotifier;

    public ApiChecker(string apiUrl, SlackNotifier slackNotifier)
    {
        _apiUrl = apiUrl;
        _slackNotifier = slackNotifier;
    }

    public async Task CheckApiAsync()
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.GetAsync(_apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    await _slackNotifier.SendMessageAsync("API is working correctly!");
                }
                else
                {
                    await _slackNotifier.SendMessageAsync($"API error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                await _slackNotifier.SendMessageAsync($"Exception occurred: {ex.Message}");
            }
        }
    }
}
