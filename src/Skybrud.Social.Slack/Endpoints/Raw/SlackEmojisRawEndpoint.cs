using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the <strong>Emojis</strong> endpoint.
    /// </summary>
    public class SlackEmojisRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SlackEmojisRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of custom emojis for a team.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/emoji.list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return Client.Get("/api/emoji.list");
        }

        #endregion

    }

}