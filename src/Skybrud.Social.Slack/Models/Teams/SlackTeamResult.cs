using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Teams {

    /// <summary>
    /// Class representing a response body with information about a Slack team.
    /// </summary>
    public class SlackTeamResult : SlackResult {

        #region Properties

        /// <summary>
        /// Gets a reference to the requested team.
        /// </summary>
        public SlackTeam Team { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackTeamResult(JObject json) : base(json) {
            Team = json.GetObject("team", SlackTeam.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackTeamResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackTeamResult"/>.</returns>
        public static SlackTeamResult Parse(JObject json) {
            return json == null ? null : new SlackTeamResult(json);
        }

        #endregion

    }

}