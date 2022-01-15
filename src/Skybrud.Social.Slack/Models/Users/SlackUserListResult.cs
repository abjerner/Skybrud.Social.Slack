using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Users {

    /// <summary>
    /// Class representing a list of Slack users (members of a Slack team).
    /// </summary>
    public class SlackUserListResult : SlackListResult {

        #region Properties

        /// <summary>
        /// Gets an array with the members of the team.
        /// </summary>
        public SlackUser[] Members { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackUserListResult(JObject json) : base(json) {
            Members = json.GetArrayItems("members", SlackUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackUserListResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackUserListResult"/>.</returns>
        public static SlackUserListResult Parse(JObject json) {
            return json == null ? null : new SlackUserListResult(json);
        }

        #endregion

    }

}