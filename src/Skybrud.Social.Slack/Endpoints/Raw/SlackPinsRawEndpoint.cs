using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.OAuth;
using Skybrud.Social.Slack.Options.Pins;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the <strong>Pins</strong> endpoint.
    /// </summary>
    public class SlackPinsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SlackPinsRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of pinned items in the specified <paramref name="channel"/>.
        /// </summary>
        /// <param name="channel">The channel to get pinned items for.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/pins.list</cref>
        /// </see>
        public IHttpResponse GetList(string channel) {
            if (string.IsNullOrWhiteSpace(channel)) throw new ArgumentNullException(nameof(channel));
            return GetList(new SlackGetPinListOptions(channel));
        }

        /// <summary>
        /// Gets a list of pinned items in the channel matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/pins.list</cref>
        /// </see>
        public IHttpResponse GetList(SlackGetPinListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}