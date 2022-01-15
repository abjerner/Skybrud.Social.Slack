using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.OAuth;
using Skybrud.Social.Slack.Options.Conversations;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the <strong>Conversions</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods?filter=conversations</cref>
    /// </see>
    public class SlackConversationsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SlackConversationsRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the conversation with the specified <paramref name="conversationId"/>.
        /// </summary>
        /// <param name="conversationId">The ID of the conversation.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.info</cref>
        /// </see>
        public IHttpResponse GetInfo(string conversationId) {
            if (string.IsNullOrWhiteSpace(conversationId)) throw new ArgumentNullException(nameof(conversationId));
            return GetInfo(new SlackGetConversationOptions(conversationId));
        }

        /// <summary>
        /// Returns information about the conversation matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.info</cref>
        /// </see>
        public IHttpResponse GetInfo(SlackGetConversationOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);

        }

        /// <summary>
        /// Returns a list of public channels.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return Client.GetResponse(new SlackGetConversationListOptions());
        }

        /// <summary>
        /// Returns a list of public channels.
        /// </summary>
        /// <param name="cursor">The cursor.</param>
        /// <param name="limit">The maximum amount of items to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.list</cref>
        /// </see>
        public IHttpResponse GetList(string cursor, int limit) {
            return Client.GetResponse(new SlackGetConversationListOptions(cursor, limit));
        }

        /// <summary>
        /// Returns a list of conversations matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.list</cref>
        /// </see>
        public IHttpResponse GetList(SlackGetConversationListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}