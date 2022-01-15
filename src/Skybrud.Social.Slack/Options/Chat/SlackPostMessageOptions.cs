using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Slack.Options.Chat {

    /// <summary>
    /// Options for posting a message to a Slack channel.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/chat.postMessage</cref>
    /// </see>
    public class SlackPostMessageOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the channel, private group, or IM channel to send the message to. Can be an encoded ID, or a name.
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the primary text of the message.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets whether the message should be posted as the authed user. Defaults to <c>false</c>.
        /// </summary>
        [JsonProperty("as_user")]
        public bool AsUser { get; set; }

        /// <summary>
        /// Get or sets a collection of attachments that should be part of the message.
        /// </summary>
        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public List<SlackMessageAttachment> Attachments { get; set; }

        /// <summary>
        /// Gets or sets the emoji to use as the icon for this message. Overrides <see cref="IconUrl"/>. Must be used
        /// in conjunction with <see cref="AsUser"/> set to <c>false</c>, otherwise ignored. This argument may not be
        /// used with newer bot tokens.
        /// </summary>
        [JsonProperty("icon_emoji", NullValueHandling = NullValueHandling.Ignore)]
        public string IconEmoji { get; set; }

        /// <summary>
        /// Gets or sets the URL to an image to use as the icon for this message. Must be used in conjunction with
        /// <see cref="AsUser"/> set to <c>false</c>, otherwise ignored. See authorship below. This argument may not
        /// be used with newer bot tokens.
        /// </summary>
        [JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets sets your bot's user name. Must be used in conjunction with as_user set to false, otherwise ignored. 
        /// </summary>
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        /// <summary>
        /// Gets whether Slack should find and link channel names and usernames.
        /// </summary>
        [JsonProperty("link_names", NullValueHandling = NullValueHandling.Ignore)]
        public bool LinkNames { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SlackPostMessageOptions() {
            Attachments = new List<SlackMessageAttachment>();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="channel"/> and <paramref name="text"/>.
        /// </summary>
        /// <param name="channel">The channel, private group, or IM channel to send the message to. Can be an encoded ID, or a name.</param>
        /// <param name="text">The primary text of the message.</param>
        public SlackPostMessageOptions(string channel, string text) {
            Channel = channel;
            Text = text;
            Attachments = new List<SlackMessageAttachment>();
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Channel)) throw new PropertyNotSetException(nameof(Channel));
            if (string.IsNullOrWhiteSpace(Text)) throw new PropertyNotSetException(nameof(Text));

            // Get the JSON for the request body
            JObject body = JObject.FromObject(this);

            // Make the request to the API
            HttpRequest request = HttpRequest.Post("/api/chat.postMessage", body);

            request.ContentType = "application/json; charset=utf-8";

            return request;

        }

        #endregion

    }

}