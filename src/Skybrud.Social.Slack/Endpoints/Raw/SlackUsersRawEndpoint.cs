using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the users endpoint.
    /// </summary>
    public class SlackUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SlackUsersRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about a team member.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.info</cref>
        /// </see>
        public IHttpResponse GetInfo(string userId) {
            return Client.Get("https://slack.com/api/users.info?user=" + userId);
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return Client.Get("https://slack.com/api/users.list");
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <param name="presence">Specifies whether presence data should be included in the output.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public IHttpResponse GetList(bool presence) {
            return Client.Get("https://slack.com/api/users.list" + (presence ? "?presence=1" : ""));
        }

        #endregion

    }

}