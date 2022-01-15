using System;
using Skybrud.Social.Slack.Endpoints;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack {

    /// <summary>
    /// Service implementation of the Slack API.
    /// </summary>
    public class SlackHttpService {

        #region Properties

        /// <summary>
        /// The internal OAuth client for communication with the Slack API.
        /// </summary>
        public SlackOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the authentication endpoint.
        /// </summary>
        public SlackAuthenticationEndpoint Authentication { get; }

        /// <summary>
        /// Gets a reference to the <strong>Channels</strong> endpoint.
        /// </summary>
        public SlackChannelsEndpoint Channels { get; }

        /// <summary>
        /// Gets a reference to the <strong>Chat</strong> endpoint.
        /// </summary>
        public SlackChatEndpoint Chat { get; }

        /// <summary>
        /// Gets a reference to the <strong>Conversations</strong> endpoint.
        /// </summary>
        public SlackConversationsEndpoint Conversations { get; }

        /// <summary>
        /// Gets a reference to the <strong>Emojis</strong> endpoint.
        /// </summary>
        public SlackEmojisEndpoint Emojis { get; }

        /// <summary>
        /// Gets a reference to the <strong>Teams</strong> endpoint.
        /// </summary>
        public SlackTeamsEndpoint Teams { get; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public SlackUsersEndpoint Users { get; }

        #endregion

        #region Constructor(s)

        private SlackHttpService(SlackOAuthClient client) {
            Client = client;
            Authentication = new SlackAuthenticationEndpoint(this);
            Channels = new SlackChannelsEndpoint(this);
            Chat = new SlackChatEndpoint(this);
            Conversations = new SlackConversationsEndpoint(this);
            Emojis = new SlackEmojisEndpoint(this);
            Teams = new SlackTeamsEndpoint(this);
            Users = new SlackUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static SlackHttpService CreateFromOAuthClient(SlackOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException(nameof(client));

            // Initialize the service
            return new SlackHttpService(client);

        }

        /// <summary>
        /// Initializes a new service instance from the specifie OAuth 2 access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static SlackHttpService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return CreateFromOAuthClient(new SlackOAuthClient {
                AccessToken = accessToken
            });
        }

        #endregion

    }

}