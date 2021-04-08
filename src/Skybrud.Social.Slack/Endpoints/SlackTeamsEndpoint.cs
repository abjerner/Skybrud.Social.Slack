using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Responses.Teams;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Teams</strong> endpoint.
    /// </summary>
    public class SlackTeamsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackTeamsRawEndpoint Raw => Service.Client.Teams;

        #endregion

        #region Constructors

        internal SlackTeamsEndpoint(SlackService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user's current team.
        /// </summary>
        /// <returns>An instance of <see cref="SlackTeamResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/team.info</cref>
        /// </see>
        public SlackTeamResponse GetInfo() {
            return new SlackTeamResponse(Raw.GetInfo());
        }

        /// <summary>
        /// Gets information about a team.
        /// </summary>
        /// <param name="team">The ID of the team.</param>
        /// <returns>An instance of <see cref="SlackTeamResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/team.info</cref>
        /// </see>
        public SlackTeamResponse GetInfo(string team) {
            return new SlackTeamResponse(Raw.GetInfo(team));
        }

        #endregion

    }

}