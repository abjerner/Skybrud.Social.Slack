using System;
using Skybrud.Social.Http;
using Skybrud.Social.Slack.Options.Chat;

namespace Skybrud.Social.Slack {

    public class SlackWebhookClient {

        #region Properties

        public string WebhookUrl { get; set; }

        #endregion

        #region Constructors

        public SlackWebhookClient(string webhookUrl) {
            WebhookUrl = webhookUrl;
        }

        #endregion

        #region Member methods

        
        public SocialHttpResponse PostMessage(SlackPostMessageOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return SlackUtils.PostMessage(WebhookUrl, options);
        }

        #endregion

    }

}