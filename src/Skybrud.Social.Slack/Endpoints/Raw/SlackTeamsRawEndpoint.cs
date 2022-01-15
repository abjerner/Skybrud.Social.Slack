using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the <strong>Teams</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods?filter=team</cref>
    /// </see>
    public class SlackTeamsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SlackTeamsRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user's current team.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/team.info</cref>
        /// </see>
        public IHttpResponse GetInfo() {
            return Client.Get("/api/team.info");
        }

        /// <summary>
        /// Gets information about a team.
        /// </summary>
        /// <param name="team">The ID of the team.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/team.info</cref>
        /// </see>
        public IHttpResponse GetInfo(string team) {
            if (string.IsNullOrWhiteSpace(team)) throw new ArgumentNullException(nameof(team));
            return Client.Get($"/api/team.info?team={team}");
        }

        #endregion

    }

}