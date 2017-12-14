using System;
using Newtonsoft.Json;
using Skybrud.Social.Http;
using Skybrud.Social.Slack.Options.Chat;

namespace Skybrud.Social.Slack {

    public static class SlackUtils {

        public static SocialHttpResponse PostMessage(string webhookUrl, SlackPostMessageOptions options) {

            if (String.IsNullOrWhiteSpace(webhookUrl)) throw new ArgumentNullException(nameof(webhookUrl));
            if (options == null) throw new ArgumentNullException(nameof(options));

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Url = webhookUrl,
                Method = SocialHttpMethod.Post,
                ContentType = "application/x-www-form-urlencoded"
            };
            
            // Append the message to the POST body
            request.PostData.Add("payload", JsonConvert.SerializeObject(options));

            // Make the request to the webhook
            return request.GetResponse();

        }

    }

}