using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the <strong>Channels</strong> endpoint.
    /// </summary>
    public class SlackChannelsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SlackChannelsRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about a channel.
        /// </summary>
        /// <param name="channel">The ID of the channel.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/channels.info</cref>
        /// </see>
        public IHttpResponse GetInfo(string channel) {
            if (string.IsNullOrWhiteSpace(channel)) throw new ArgumentNullException(nameof(channel));
            return Client.Get("https://slack.com/api/channels.info?channel=" + channel);
        }

        /// <summary>
        /// Gets a list of all channels in the team.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/channels.list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return Client.Get("https://slack.com/api/channels.list");
        }

        #endregion

    }

}