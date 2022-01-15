using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Options.Conversations;
using Skybrud.Social.Slack.Responses.Conversations;

namespace Skybrud.Social.Slack.Endpoints {
    
    /// <summary>
    /// Implementation of the <strong>Conversions</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods?filter=conversations</cref>
    /// </see>
    public class SlackConversationsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackHttpService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackConversationsRawEndpoint Raw => Service.Client.Conversations;

        #endregion

        #region Constructors

        internal SlackConversationsEndpoint(SlackHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the conversation with the specified <paramref name="conversationId"/>.
        /// </summary>
        /// <param name="conversationId">The ID of the conversation.</param>
        /// <returns>An instance of <see cref="SlackConversationResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.info</cref>
        /// </see>
        public SlackConversationResponse GetInfo(string conversationId) {
            return new SlackConversationResponse(Raw.GetInfo(conversationId));
        }

        /// <summary>
        /// Returns information about the conversation matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SlackConversationResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.info</cref>
        /// </see>
        public SlackConversationResponse GetInfo(SlackGetConversationOptions options) {
            return new SlackConversationResponse(Raw.GetInfo(options));

        }
        
        /// <summary>
        /// Returns a list of public channels.
        /// </summary>
        /// <returns>An instance of <see cref="SlackConversationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.list</cref>
        /// </see>
        public SlackConversationListResponse GetList() {
            return new SlackConversationListResponse(Raw.GetList());
        }
        
        /// <summary>
        /// Returns a list of public channels.
        /// </summary>
        /// <param name="cursor">The cursor.</param>
        /// <param name="limit">The maximum amount of items to be returned.</param>
        /// <returns>An instance of <see cref="SlackConversationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.list</cref>
        /// </see>
        public SlackConversationListResponse GetList(string cursor, int limit) {
            return new SlackConversationListResponse(Raw.GetList(cursor, limit));
        }
        
        /// <summary>
        /// Returns a list of conversations matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SlackConversationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/conversations.list</cref>
        /// </see>
        public SlackConversationListResponse GetList(SlackGetConversationListOptions options) {
            return new SlackConversationListResponse(Raw.GetList(options));
        }

        #endregion

    }

}