using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Teams {
    
    public class SlackTeamResponseBody : SlackResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to the requested team.
        /// </summary>
        public SlackTeam Team { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackTeamResponseBody(JObject obj) : base(obj) {
            Team = obj.GetObject("team", SlackTeam.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackTeamResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackTeamResponseBody"/>.</returns>
        public static SlackTeamResponseBody Parse(JObject obj) {
            return obj == null ? null : new SlackTeamResponseBody(obj);
        }

        #endregion

    }

}