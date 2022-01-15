using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the authentication endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods?filter=auth</cref>
    /// </see>
    public class SlackAuthenticationRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SlackAuthenticationRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// This method checks authentication and tells "you" who you are, even if you might be a bot.
        ///
        /// You can also use this method to test whether Slack API authentication is functional.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/auth.test</cref>
        /// </see>
        public IHttpResponse GetTest() {
            return Client.Get("/api/auth.test");
        }

        #endregion

    }

}