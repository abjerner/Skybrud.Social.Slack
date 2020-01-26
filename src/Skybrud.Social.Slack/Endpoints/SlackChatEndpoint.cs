using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Options.Chat;
using Skybrud.Social.Slack.Responses.Chat;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Chat</strong> endpoint.
    /// </summary>
    public class SlackChatEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackChatRawEndpoint Raw => Service.Client.Chat;

        #endregion

        #region Constructors

        internal SlackChatEndpoint(SlackService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Posts a new message to the channel, private group, or IM channel described by the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SlackPostMessageResponse"/> representing the response from the API.</returns>
        public SlackPostMessageResponse PostMessage(SlackPostMessageOptions options) {
            return SlackPostMessageResponse.Parse(Raw.PostMessage(options));
        }

        #endregion

    }

}