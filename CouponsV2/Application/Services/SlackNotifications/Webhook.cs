using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace CouponsV2.Application.Services
{
    public class Webhook
    {
        public async void SendWebhook()
        {
            try
            {
                string webhookUrl = "https://hooks.slack.com/services/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";

                //https://api.slack.com/apps/A079KFM0CTA/incoming-webhooks?success=1 -> For modificate the HOOK

                string jsonBody = "{'text' : 'EndPoint was consummed with success'}";

                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(webhookUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Enviado");
                    }
                    else
                    {
                        Console.WriteLine("No enviado");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An enrror ocurred while sending the webhook");
                Console.WriteLine(ex);
            }
        }
    }
}