using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Authentication {
    
    public class SlackAuthenticationTest : SlackObject {

        #region Properties

        public string Url { get; }

        public string Team { get; }

        public string User { get; }

        public string TeamId { get; }

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