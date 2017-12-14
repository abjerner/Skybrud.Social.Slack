using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the chat endpoint.
    /// </summary>
    public class SlackChatRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal SlackChatRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods
        

        #endregion

    }

}