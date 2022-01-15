using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Authentication {

    /// <summary>
    /// Class with brief information about the authed user.
    /// </summary>
    public class SlackAuthenticationTest : SlackResult {

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

        /// <summary>
        /// Gets whether the user is part of an enterprise install.
        /// </summary>
        public bool IsEnterpriseInstall { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackAuthenticationTest(JObject json) : base(json) {
            Url = json.GetString("url");
            Team = json.GetString("team");
            User = json.GetString("user");
            TeamId = json.GetString("team_id");
            UserId = json.GetString("user_id");
            IsEnterpriseInstall = json.GetBoolean("is_enterprise_install");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackAuthenticationTest"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SlackAuthenticationTest"/>.</returns>
        public static SlackAuthenticationTest Parse(JObject json) {
            return json == null ? null : new SlackAuthenticationTest(json);
        }

        #endregion

    }

}