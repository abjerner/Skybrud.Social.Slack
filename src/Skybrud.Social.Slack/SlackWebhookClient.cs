using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Options.Chat;

namespace Skybrud.Social.Slack {

    /// <summary>
    /// Webhook client used for posting messages to a Slack channel.
    /// </summary>
    public class SlackWebhookClient {

        #region Properties

        /// <summary>
        /// Gets or sets the webhook URL.
        /// </summary>
        public string WebhookUrl { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="webhookUrl"/>.
        /// </summary>
        /// <param name="webhookUrl">The webhook URL.</param>
        public SlackWebhookClient(string webhookUrl) {
            WebhookUrl = webhookUrl;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Posts a new message to a Slack channel.
        /// </summary>
        /// <param name="options">The options describing the message to post.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the server response.</returns>
        public IHttpResponse PostMessage(SlackPostMessageOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return SlackUtils.PostMessage(WebhookUrl, options);
        }

        #endregion

    }

}