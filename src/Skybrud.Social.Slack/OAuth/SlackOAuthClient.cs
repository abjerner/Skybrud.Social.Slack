using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Responses.Authentication;
using Skybrud.Social.Slack.Scopes;

namespace Skybrud.Social.Slack.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Slack API as well as any OAuth 2.0 communication.
    /// </summary>
    public class SlackOAuthClient : HttpClient {

        #region Properties

        #region OAuth

        /// <summary>
        /// Gets or sets the ID of the client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret of the client.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your client.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        #endregion

        #region Endpoints

        /// <summary>
        /// Gets a reference to the raw <strong>Authentication</strong> endpoint.
        /// </summary>
        public SlackAuthenticationRawEndpoint Authentication { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Channels</strong> endpoint.
        /// </summary>
        public SlackChannelsRawEndpoint Channels { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Chat</strong> endpoint.
        /// </summary>
        public SlackChatRawEndpoint Chat { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Conversations</strong> endpoint.
        /// </summary>
        public SlackConversationsRawEndpoint Conversations { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Emojis</strong> endpoint.
        /// </summary>
        public SlackEmojisRawEndpoint Emojis { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Pins</strong> endpoint.
        /// </summary>
        public SlackPinsRawEndpoint Pins { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Teams</strong> endpoint.
        /// </summary>
        public SlackTeamsRawEndpoint Teams { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Users</strong> endpoint.
        /// </summary>
        public SlackUsersRawEndpoint Users { get; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public SlackOAuthClient() {
            Authentication = new SlackAuthenticationRawEndpoint(this);
            Channels = new SlackChannelsRawEndpoint(this);
            Chat = new SlackChatRawEndpoint(this);
            Conversations = new SlackConversationsRawEndpoint(this);
            Emojis = new SlackEmojisRawEndpoint(this);
            Pins = new SlackPinsRawEndpoint(this);
            Teams = new SlackTeamsRawEndpoint(this);
            Users = new SlackUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public SlackOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public SlackOAuthClient(long clientId, string clientSecret) : this() {
            ClientId = clientId.ToString();
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public SlackOAuthClient(long clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId.ToString();
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public SlackOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public SlackOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/>. This URL will only make your application
        /// request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <returns>An authorization URL based on <paramref name="state"/>.</returns>
        public string GetAuthorizationUrl(string state) {

            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));

            HttpQueryString query = new HttpQueryString {
                {"client_id", ClientId},
                { "redirect_uri", RedirectUri},
                { "state", state}
            };

            return $"https://slack.com/oauth/authorize?{query}";

        }

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>An authorization URL based on <paramref name="state"/> and <paramref name="scope"/>.</returns>
        public string GetAuthorizationUrl(string state, SlackScopeList scope) {

            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
            if (scope == null) throw new ArgumentNullException(nameof(scope));

            HttpQueryString query = new HttpQueryString {
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"state", state},
                {"scope", scope}
            };

            return $"https://slack.com/oauth/authorize?{query}";

        }

        /// <summary>
        /// Exchanges the specified authorization code for a refresh token and an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Slack OAuth dialog.</param>
        /// <returns>An access token based on the specified <paramref name="authCode"/>.</returns>
        public SlackTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            if (string.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException(nameof(authCode));

            // Initialize collection with POST data
            IHttpPostData parameters = new HttpPostData {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri},
                {"code", authCode }
            };

            // Make the call to the API
            IHttpResponse response = HttpUtils.Requests.Post("https://slack.com/api/oauth.access", parameters);

            // Parse the response
            return new SlackTokenResponse(response);

        }

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Append the "Authorization" header when an access token is present
            if (string.IsNullOrWhiteSpace(AccessToken) == false) {
                request.Headers.Authorization = $"Bearer {AccessToken}";
            }

            // Append the scheme and host if not already present in the URL
            if (request.Url.StartsWith("/api")) request.Url = $"https://slack.com{request.Url}";

        }

        #endregion

    }

}