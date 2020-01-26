using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Authentication {
    
    /// <summary>
    /// Class with brief information about the authed user.
    /// </summary>
    public class SlackAuthenticationTest : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the web URL of the user's Slack team.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the name of the user's Slack team.
        /// </summary>
        public string Team { get; }

        /// <summary>
        /// Gets the username of the authed user.
        /// </summary>
        public string User { get; }

        /// <summary>
        /// gets the ID of the user's team.
        /// </summary>
        public string TeamId { get; }

        /// <summary>
        /// Gets the ID if the authed user.
        /// </summary>
        public string UserId { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackAuthenticationTest(JObject obj) : base(obj) {
            Url = obj.GetString("url");
            Team = obj.GetString("team");
            User = obj.GetString("user");
            TeamId = obj.GetString("team_id");
            UserId = obj.GetString("user_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackAuthenticationTest"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SlackAuthenticationTest"/>.</returns>
        public static SlackAuthenticationTest Parse(JObject obj) {
            return obj == null ? null : new SlackAuthenticationTest(obj);
        }

        #endregion

    }

}